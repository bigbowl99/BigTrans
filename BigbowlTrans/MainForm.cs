using OpenAI_API;
using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;




namespace BigbowlTrans
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        private OpenAIAPI key_api;
        private OpenAI_API.Chat.Conversation key_chat;
        private static readonly string filePath = "chatLog.html";


        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi; // 或 AutoScaleMode.Dpi
            this.KeyPreview = true;
            GlobalHotKey.HotkeyPressed += GlobalHotkey_HotkeyPressed;


            InitOpenAI();

        }

        private void InitOpenAI()
        {
            Configuration config = new Configuration();
           
            key_api = new OpenAIAPI(config.OpenAIKey,config.ProxyServer);
            key_chat = key_api.Chat.CreateConversation();
            key_chat.Model = OpenAI_API.Models.Model.ChatGPTTurbo;
            key_chat.RequestParameters.Temperature = 0;
            //key_chat.AppendSystemMessage("You are an excellent master of Chinese-English translation, automatically recognizing whether the input text is in Chinese or English, responsible for translating from Chinese to English and from English to Chinese. If the input is an English word, you act as a dictionary, providing the Chinese and English definitions, pronunciation, and common usage sentences of the word. If the input is a Chinese term, you provide various common expressions of the term in English, noting that the corresponding expressions may not necessarily be single English words, but could also be combinations of words.");

            key_chat.AppendSystemMessage(config.Instruction);



        }

        private void GlobalHotkey_HotkeyPressed()
        {
            Invoke(new Action(() =>
            {
                if (Clipboard.ContainsText())
                {
                    leftBox.Text = Clipboard.GetText();
                    // TODO: 调用翻译 API 并将结果显示到 rightBox 中
                    TransLeft();
                    BringToFront();
                }
            }));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;

            // 设置窗口的最大大小为屏幕的宽度和高度的某个百分比
            int maxWidth = (int)(screenSize.Width * 0.9); // 例如，屏幕宽度的 80%
            int maxHeight = (int)(screenSize.Height * 0.9); // 屏幕高度的 80%

            // 设置窗口的大小，但不超过最大值
            this.Size = new Size(Math.Min(1280, maxWidth), Math.Min(960, maxHeight));
            GlobalHotKey.SetHook();

            //设置自启动
            SetAutoStart("bigbowltrans", true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalHotKey.UnsetHook();
        }

        private void BringToFront()
        {
            // 获取当前窗口和前台窗口的线程ID
            IntPtr foregroundWindow = GetForegroundWindow();
            uint currentThreadId = GetCurrentThreadId();
            uint foregroundThreadId = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);

            // 将两个线程附加到一起
            AttachThreadInput(currentThreadId, foregroundThreadId, true);

            // 尝试将窗口置于前台
            SetForegroundWindow(this.Handle);

            // 分离线程
            AttachThreadInput(currentThreadId, foregroundThreadId, false);
        }

        private async void btnLeft2Right_Click(object sender, EventArgs e)
        {
            TransLeft();
        }

        public static string FormatString(string input)
        {
            input = input.Replace("\r\n", "\n");
            input = input.Replace("\n", "\r\n");
            // 规则1: 所有的中英文冒号后面加换行
            input = Regex.Replace(input, "[:：]", "$0\r\n");

            // 规则2: 所有的数字列表前面加换行
            input = Regex.Replace(input, @"(?<=\S)(\s\d+\.)", "\r\n$1");

            // 规则3: 在整个字符串的最前面加一个换行
            input = "\r\n" + input;

            return input;
        }

        private async void TransLeft()
        {
            string userMessage = leftBox.Text;

            pbLoading.Visible = true;
            if (!string.IsNullOrEmpty(userMessage))
            {
                try
                {
                    key_chat.AppendUserInput(userMessage);
                    string response = await key_chat.GetResponseFromChatbotAsync();
                    string rihgt_string = FormatString(response);
                    rightBox.Text = rihgt_string;
                }
                catch (Exception ex)
                {
                    // 处理异常（如显示错误消息）
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            pbLoading.Visible = false;
            SaveChatMessage(userMessage, rightBox.Text);
        }

        private async void TransRight()
        {
            string userMessage = rightBox.Text;
            pbLoading.Visible = true;
            if (!string.IsNullOrEmpty(userMessage))
            {
                try
                {
                    key_chat.AppendUserInput(userMessage);
                    string response = await key_chat.GetResponseFromChatbotAsync();
                    string rihgt_string = FormatString(response);
                    leftBox.Text = rihgt_string;
                }
                catch (Exception ex)
                {
                    // 处理异常（如显示错误消息）
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            pbLoading.Visible = false;
            SaveChatMessage(userMessage, leftBox.Text);
        }

        private void btnRight2Left_Click(object sender, EventArgs e)
        {
            TransRight();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    TransRight(); // 调用 TransRight 方法
                    break;
                case Keys.Right:
                    TransLeft(); // 调用 TransLeft 方法
                    break;
                case Keys.Enter:
                    TransLeft(); // 调用 TransLeft 方法
                    break;
            }
        }

        public static void SaveChatMessage(string userMessage, string AIMessage)
        {
            try
            {
                string newTableRow = $@"
                                        <tr>
                                            <td>{userMessage.Replace("\r\n", "<br>")}</td>
                                            <td>{AIMessage.Replace("\r\n", "<br>")}</td>
                                        </tr>";

                if (!File.Exists(filePath))
                {
                    string htmlStart = $@"
                                        <html>
                                        <head>
                                            <title>Chat Log</title>
                                            <style>
                                                body {{ font-family: Arial, sans-serif; }}
                                                table {{ width: 100%; border-collapse: collapse; }}
                                                th {{ background-color: #90ee90; }} /* 绿色小清新标题头颜色 */
                                                td {{ padding: 10px; vertical-align: top; text-align: left; }}
                                                .header {{ text-align: center; }}
                                            </style>
                                        </head>
                                        <body>
                                            <h2 class='header'>Chat Session Log</h2>
                                            <table>
                                                <tr>
                                                    <th>源文字</th>
                                                    <th>目标文字</th>
                                                </tr>
                                                {newTableRow}
                                            </table>
                                        </body>
                                        </html>";

                    File.WriteAllText(filePath, htmlStart, Encoding.UTF8);
                }
                else
                {
                    // 读取现有文件内容
                    string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);

                    // 在 </table> 标签前插入新的聊天记录
                    htmlContent = htmlContent.Replace("</table>", $"{newTableRow}</table>");

                    // 重写文件
                    File.WriteAllText(filePath, htmlContent, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving chat message: {ex.Message}");
            }
        }



        private void btnSetting_Click(object sender, EventArgs e)
        {
            //Configuration.EditConfigFileWithNotepad();
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
            //无论settingForm是否更改了配置文件，都要重新加载配置文件
            InitOpenAI();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", $"\"{filePath}\"");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            leftBox.Text = "";
            rightBox.Text = "";
        }

        private void pbLoading_Click(object sender, EventArgs e)
        {

        }

        public static void SetAutoStart(string appName, bool enable)
        {
            string exePath = Assembly.GetExecutingAssembly().Location;

            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (enable)
                {
                    key.SetValue(appName, exePath);
                }
                else
                {
                    key.DeleteValue(appName, false);
                }
            }
        }
    }

}
