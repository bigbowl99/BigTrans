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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi; // �� AutoScaleMode.Dpi
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
                    // TODO: ���÷��� API ���������ʾ�� rightBox ��
                    TransLeft();
                    BringToFront();
                }
            }));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;

            // ���ô��ڵ�����СΪ��Ļ�Ŀ�Ⱥ͸߶ȵ�ĳ���ٷֱ�
            int maxWidth = (int)(screenSize.Width * 0.9); // ���磬��Ļ��ȵ� 80%
            int maxHeight = (int)(screenSize.Height * 0.9); // ��Ļ�߶ȵ� 80%

            // ���ô��ڵĴ�С�������������ֵ
            this.Size = new Size(Math.Min(1280, maxWidth), Math.Min(960, maxHeight));
            GlobalHotKey.SetHook();

            //����������
            SetAutoStart("bigbowltrans", true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalHotKey.UnsetHook();
        }

        private void BringToFront()
        {
            // ��ȡ��ǰ���ں�ǰ̨���ڵ��߳�ID
            IntPtr foregroundWindow = GetForegroundWindow();
            uint currentThreadId = GetCurrentThreadId();
            uint foregroundThreadId = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);

            // �������̸߳��ӵ�һ��
            AttachThreadInput(currentThreadId, foregroundThreadId, true);

            // ���Խ���������ǰ̨
            SetForegroundWindow(this.Handle);

            // �����߳�
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
            // ����1: ���е���Ӣ��ð�ź���ӻ���
            input = Regex.Replace(input, "[:��]", "$0\r\n");

            // ����2: ���е������б�ǰ��ӻ���
            input = Regex.Replace(input, @"(?<=\S)(\s\d+\.)", "\r\n$1");

            // ����3: �������ַ�������ǰ���һ������
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
                    // �����쳣������ʾ������Ϣ��
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
                    // �����쳣������ʾ������Ϣ��
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
                    TransRight(); // ���� TransRight ����
                    break;
                case Keys.Right:
                    TransLeft(); // ���� TransLeft ����
                    break;
                case Keys.Enter:
                    TransLeft(); // ���� TransLeft ����
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
                                                th {{ background-color: #90ee90; }} /* ��ɫС���±���ͷ��ɫ */
                                                td {{ padding: 10px; vertical-align: top; text-align: left; }}
                                                .header {{ text-align: center; }}
                                            </style>
                                        </head>
                                        <body>
                                            <h2 class='header'>Chat Session Log</h2>
                                            <table>
                                                <tr>
                                                    <th>Դ����</th>
                                                    <th>Ŀ������</th>
                                                </tr>
                                                {newTableRow}
                                            </table>
                                        </body>
                                        </html>";

                    File.WriteAllText(filePath, htmlStart, Encoding.UTF8);
                }
                else
                {
                    // ��ȡ�����ļ�����
                    string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);

                    // �� </table> ��ǩǰ�����µ������¼
                    htmlContent = htmlContent.Replace("</table>", $"{newTableRow}</table>");

                    // ��д�ļ�
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
            //����settingForm�Ƿ�����������ļ�����Ҫ���¼��������ļ�
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
