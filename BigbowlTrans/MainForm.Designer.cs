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
            btnSetting = new Button();
            btnHistory = new Button();
            btnClear = new Button();
            rightBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pbLoading = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoading).BeginInit();
            SuspendLayout();
            // 
            // leftBox
            // 
            leftBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leftBox.BorderStyle = BorderStyle.None;
            leftBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            leftBox.Location = new Point(10, 10);
            leftBox.Margin = new Padding(10);
            leftBox.Multiline = true;
            leftBox.Name = "leftBox";
            leftBox.ScrollBars = ScrollBars.Vertical;
            leftBox.Size = new Size(607, 800);
            leftBox.TabIndex = 0;
            // 
            // btnLeft2Right
            // 
            btnLeft2Right.Anchor = AnchorStyles.None;
            btnLeft2Right.BackgroundImage = (Image)resources.GetObject("btnLeft2Right.BackgroundImage");
            btnLeft2Right.BackgroundImageLayout = ImageLayout.Stretch;
            btnLeft2Right.FlatAppearance.BorderSize = 0;
            btnLeft2Right.FlatStyle = FlatStyle.Flat;
            btnLeft2Right.Location = new Point(375, 3);
            btnLeft2Right.Name = "btnLeft2Right";
            btnLeft2Right.Size = new Size(94, 74);
            btnLeft2Right.TabIndex = 1;
            btnLeft2Right.UseVisualStyleBackColor = true;
            btnLeft2Right.Click += btnLeft2Right_Click;
            // 
            // btnRight2Left
            // 
            btnRight2Left.Anchor = AnchorStyles.None;
            btnRight2Left.BackgroundImage = (Image)resources.GetObject("btnRight2Left.BackgroundImage");
            btnRight2Left.BackgroundImageLayout = ImageLayout.Stretch;
            btnRight2Left.FlatAppearance.BorderSize = 0;
            btnRight2Left.FlatStyle = FlatStyle.Flat;
            btnRight2Left.Location = new Point(695, 3);
            btnRight2Left.Name = "btnRight2Left";
            btnRight2Left.Size = new Size(93, 74);
            btnRight2Left.TabIndex = 2;
            btnRight2Left.UseVisualStyleBackColor = true;
            btnRight2Left.Click += btnRight2Left_Click;
            // 
            // btnSetting
            // 
            btnSetting.Anchor = AnchorStyles.None;
            btnSetting.BackgroundImage = (Image)resources.GetObject("btnSetting.BackgroundImage");
            btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Location = new Point(3, 5);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(64, 70);
            btnSetting.TabIndex = 4;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.None;
            btnHistory.BackgroundImage = (Image)resources.GetObject("btnHistory.BackgroundImage");
            btnHistory.BackgroundImageLayout = ImageLayout.Stretch;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(145, 3);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(66, 74);
            btnHistory.TabIndex = 4;
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.None;
            btnClear.BackgroundImage = (Image)resources.GetObject("btnClear.BackgroundImage");
            btnClear.BackgroundImageLayout = ImageLayout.Stretch;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(73, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(66, 74);
            btnClear.TabIndex = 4;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // rightBox
            // 
            rightBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rightBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rightBox.Location = new Point(637, 10);
            rightBox.Margin = new Padding(10);
            rightBox.Multiline = true;
            rightBox.Name = "rightBox";
            rightBox.ScrollBars = ScrollBars.Vertical;
            rightBox.Size = new Size(608, 800);
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
            tableLayoutPanel1.Location = new Point(1, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1255, 820);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel2.Controls.Add(pbLoading, 5, 0);
            tableLayoutPanel2.Controls.Add(btnSetting, 0, 0);
            tableLayoutPanel2.Controls.Add(btnHistory, 2, 0);
            tableLayoutPanel2.Controls.Add(btnRight2Left, 4, 0);
            tableLayoutPanel2.Controls.Add(btnLeft2Right, 3, 0);
            tableLayoutPanel2.Controls.Add(btnClear, 1, 0);
            tableLayoutPanel2.Location = new Point(1, 827);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 81F));
            tableLayoutPanel2.Size = new Size(1255, 80);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // pbLoading
            // 
            pbLoading.Anchor = AnchorStyles.None;
            pbLoading.Image = (Image)resources.GetObject("pbLoading.Image");
            pbLoading.Location = new Point(885, 3);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new Size(339, 74);
            pbLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLoading.TabIndex = 3;
            pbLoading.TabStop = false;
            pbLoading.Visible = false;
            pbLoading.Click += pbLoading_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 913);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "BigTrans";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLoading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox leftBox;
        private Button btnLeft2Right;
        private Button btnRight2Left;
        private Button btnSetting;
        private Button btnHistory;
        public Button btnClear;
        private TextBox rightBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pbLoading;
    }
}
