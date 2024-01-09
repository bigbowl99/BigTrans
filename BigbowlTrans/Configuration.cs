using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BigbowlTrans
{
    public class Configuration
    {
        public string OpenAIKey { get; set; } = string.Empty;
        public string ProxyServer { get; set; } = string.Empty;
        public string GeminiKey { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;

        private const string ConfigFilePath = "config.ini"; // 更改为 .ini 扩展名

        public Configuration()
        {
            LoadConfiguration();
        }

        public void LoadConfiguration()
        {
            if (File.Exists(ConfigFilePath))
            {
                var lines = File.ReadAllLines(ConfigFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        var key = parts[0].Trim();
                        var value = parts[1].Trim();

                        switch (key)
                        {
                            case "OpenAIKey":
                                OpenAIKey = value;
                                break;
                            case "ProxyServer":
                                ProxyServer = value;
                                //如果代理服务器域名不符合域名规范，就清空
                                if (!Uri.CheckHostName(ProxyServer).Equals(UriHostNameType.Dns))
                                {
                                    ProxyServer = string.Empty;
                                }
                                break;
                            case "GeminiKey":
                                GeminiKey = value;
                                break;
                            case "Instruction":
                                Instruction = value;
                                //我要在加载时把instruction的换行符替换回来
                                Instruction = Instruction.Replace("\\n", "\r\n");
                                break;
                        }
                    }
                }
            }
            else
            {
                CreateDefaultConfigFile();
            }
        }

        public static void CreateDefaultConfigFile()
        {
            // 检查文件是否已存在
            if (!File.Exists(ConfigFilePath))
            {
                var defaultContent = new List<string>
            {
                "OpenAIKey=",
                "ProxyServer=",
                "GeminiKey=",
                "Instruction=You are an excellent master of Chinese-English translation, automatically recognizing whether the input text is in Chinese or English, responsible for translating from Chinese to English and from English to Chinese. If the input is an English word, you act as a dictionary, providing the Chinese and English definitions, pronunciation, and common usage sentences of the word. If the input is a Chinese term, you provide various common expressions of the term in English, noting that the corresponding expressions may not necessarily be single English words, but could also be combinations of words."
            };

                // 创建并写入默认内容
                File.WriteAllLines(ConfigFilePath, defaultContent, Encoding.UTF8);
            }
        }

        public void SaveConfiguration()
        {
            //我要在保存前把instruction的换行符替换掉
            Instruction = Instruction.Replace("\r\n", "\\n");
            var lines = new List<string>
            {
                $"OpenAIKey={OpenAIKey}",
                $"ProxyServer={ProxyServer}",
                $"GeminiKey={GeminiKey}",
                $"Instruction={Instruction}"
            };

            File.WriteAllLines(ConfigFilePath, lines);
        }

        public static void EditConfigFileWithNotepad()
        {
            // 启动 notepad 并打开配置文件
            Process.Start("notepad.exe", ConfigFilePath);
        }
    }
}
