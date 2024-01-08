namespace BigbowlTrans
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            label1 = new Label();
            apiKeyBox = new TextBox();
            label2 = new Label();
            proxyBox = new TextBox();
            label3 = new Label();
            geminiKeyBox = new TextBox();
            label4 = new Label();
            instructBox = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(37, 114);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 0;
            label1.Text = "OpenAI API Key";
            // 
            // apiKeyBox
            // 
            apiKeyBox.Location = new Point(218, 111);
            apiKeyBox.Name = "apiKeyBox";
            apiKeyBox.Size = new Size(677, 27);
            apiKeyBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(65, 56);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 0;
            label2.Text = "Proxy Server";
            // 
            // proxyBox
            // 
            proxyBox.Location = new Point(218, 49);
            proxyBox.Name = "proxyBox";
            proxyBox.Size = new Size(677, 27);
            proxyBox.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(9, 179);
            label3.Name = "label3";
            label3.Size = new Size(183, 25);
            label3.TabIndex = 0;
            label3.Text = "Google Gemini Key";
            // 
            // geminiKeyBox
            // 
            geminiKeyBox.Location = new Point(218, 179);
            geminiKeyBox.Name = "geminiKeyBox";
            geminiKeyBox.Size = new Size(677, 27);
            geminiKeyBox.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(356, 225);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 0;
            label4.Text = "Instructions";
            // 
            // instructBox
            // 
            instructBox.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            instructBox.Location = new Point(21, 270);
            instructBox.Multiline = true;
            instructBox.Name = "instructBox";
            instructBox.Size = new Size(874, 318);
            instructBox.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.Location = new Point(653, 587);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(235, 47);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Settings";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 635);
            Controls.Add(btnSave);
            Controls.Add(proxyBox);
            Controls.Add(instructBox);
            Controls.Add(geminiKeyBox);
            Controls.Add(apiKeyBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SettingForm";
            Text = "SettingForm";
            Load += SettingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox apiKeyBox;
        private Label label2;
        private TextBox proxyBox;
        private Label label3;
        private TextBox geminiKeyBox;
        private Label label4;
        private TextBox instructBox;
        private Button btnSave;
    }
}