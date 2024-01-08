namespace BigbowlTrans
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            leftBox = new TextBox();
            btnLeft2Right = new Button();
            btnRight2Left = new Button();
            pbLoading = new PictureBox();
            btnSetting = new Button();
            btnHistory = new Button();
            btnClear = new Button();
            rightBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pbLoading).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // leftBox
            // 
            leftBox.BorderStyle = BorderStyle.None;
            leftBox.Dock = DockStyle.Fill;
            leftBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            leftBox.Location = new Point(10, 10);
            leftBox.Margin = new Padding(10);
            leftBox.Multiline = true;
            leftBox.Name = "leftBox";
            leftBox.ScrollBars = ScrollBars.Vertical;
            leftBox.Size = new Size(796, 1028);
            leftBox.TabIndex = 0;
            // 
            // btnLeft2Right
            // 
            btnLeft2Right.Anchor = AnchorStyles.Bottom;
            btnLeft2Right.BackgroundImage = (Image)resources.GetObject("btnLeft2Right.BackgroundImage");
            btnLeft2Right.BackgroundImageLayout = ImageLayout.Stretch;
            btnLeft2Right.FlatAppearance.BorderSize = 0;
            btnLeft2Right.FlatStyle = FlatStyle.Flat;
            btnLeft2Right.Location = new Point(648, 1052);
            btnLeft2Right.Name = "btnLeft2Right";
            btnLeft2Right.Size = new Size(94, 68);
            btnLeft2Right.TabIndex = 1;
            btnLeft2Right.UseVisualStyleBackColor = true;
            btnLeft2Right.Click += btnLeft2Right_Click;
            // 
            // btnRight2Left
            // 
            btnRight2Left.Anchor = AnchorStyles.Bottom;
            btnRight2Left.BackgroundImage = (Image)resources.GetObject("btnRight2Left.BackgroundImage");
            btnRight2Left.BackgroundImageLayout = ImageLayout.Stretch;
            btnRight2Left.FlatAppearance.BorderSize = 0;
            btnRight2Left.FlatStyle = FlatStyle.Flat;
            btnRight2Left.Location = new Point(867, 1052);
            btnRight2Left.Name = "btnRight2Left";
            btnRight2Left.Size = new Size(93, 68);
            btnRight2Left.TabIndex = 2;
            btnRight2Left.UseVisualStyleBackColor = true;
            btnRight2Left.Click += btnRight2Left_Click;
            // 
            // pbLoading
            // 
            pbLoading.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pbLoading.Image = (Image)resources.GetObject("pbLoading.Image");
            pbLoading.Location = new Point(1200, 1040);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new Size(406, 80);
            pbLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLoading.TabIndex = 3;
            pbLoading.TabStop = false;
            pbLoading.Visible = false;
            pbLoading.Click += pbLoading_Click;
            // 
            // btnSetting
            // 
            btnSetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSetting.BackgroundImage = (Image)resources.GetObject("btnSetting.BackgroundImage");
            btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Location = new Point(12, 1052);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(61, 65);
            btnSetting.TabIndex = 4;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHistory.BackgroundImage = (Image)resources.GetObject("btnHistory.BackgroundImage");
            btnHistory.BackgroundImageLayout = ImageLayout.Stretch;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(79, 1055);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(61, 65);
            btnHistory.TabIndex = 4;
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.BackgroundImage = (Image)resources.GetObject("btnClear.BackgroundImage");
            btnClear.BackgroundImageLayout = ImageLayout.Stretch;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(146, 1055);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(63, 65);
            btnClear.TabIndex = 4;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // rightBox
            // 
            rightBox.Dock = DockStyle.Fill;
            rightBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rightBox.Location = new Point(826, 10);
            rightBox.Margin = new Padding(10);
            rightBox.Multiline = true;
            rightBox.Name = "rightBox";
            rightBox.ScrollBars = ScrollBars.Vertical;
            rightBox.Size = new Size(796, 1028);
            rightBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(leftBox, 0, 0);
            tableLayoutPanel1.Controls.Add(rightBox, 1, 0);
            tableLayoutPanel1.Location = new Point(-10, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1632, 1048);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1618, 1120);
            Controls.Add(pbLoading);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnClear);
            Controls.Add(btnHistory);
            Controls.Add(btnSetting);
            Controls.Add(btnRight2Left);
            Controls.Add(btnLeft2Right);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "BigbowlTrans";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbLoading).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox leftBox;
        private Button btnLeft2Right;
        private Button btnRight2Left;
        private PictureBox pbLoading;
        private Button btnSetting;
        private Button btnHistory;
        public Button btnClear;
        private TextBox rightBox;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
