using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigbowlTrans
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

      

        private void SettingForm_Load(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            apiKeyBox.Text = config.OpenAIKey;
            proxyBox.Text = config.ProxyServer;
            geminiKeyBox.Text = config.GeminiKey;
            instructBox.Text = config.Instruction;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            config.OpenAIKey = apiKeyBox.Text;
            config.ProxyServer = proxyBox.Text;
            config.GeminiKey = geminiKeyBox.Text;
            config.Instruction = instructBox.Text;
            config.SaveConfiguration();
            this.Close();
        }
    }
}
