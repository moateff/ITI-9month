namespace lab13
{
    partial class Form1
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
            btnOpen = new Button();
            btnSave = new Button();
            btnClose = new Button();
            btnFont = new Button();
            btnColor = new Button();
            btnCustom = new Button();
            rtbEditor = new RichTextBox();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(12, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.Location = new Point(178, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(397, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnFont
            // 
            btnFont.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFont.Location = new Point(12, 226);
            btnFont.Name = "btnFont";
            btnFont.Size = new Size(75, 23);
            btnFont.TabIndex = 4;
            btnFont.Text = "Font";
            btnFont.UseVisualStyleBackColor = true;
            btnFont.Click += btnFont_Click;
            // 
            // btnColor
            // 
            btnColor.Anchor = AnchorStyles.Bottom;
            btnColor.Location = new Point(178, 226);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(91, 23);
            btnColor.TabIndex = 5;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnCustom
            // 
            btnCustom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCustom.Location = new Point(397, 226);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(75, 23);
            btnCustom.TabIndex = 6;
            btnCustom.Text = "Custom";
            btnCustom.UseVisualStyleBackColor = true;
            btnCustom.Click += btnCustom_Click;
            // 
            // rtbEditor
            // 
            rtbEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbEditor.Location = new Point(12, 41);
            rtbEditor.Name = "rtbEditor";
            rtbEditor.Size = new Size(460, 179);
            rtbEditor.TabIndex = 0;
            rtbEditor.Text = "Write Here ...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(rtbEditor);
            Controls.Add(btnCustom);
            Controls.Add(btnColor);
            Controls.Add(btnFont);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            MinimumSize = new Size(500, 300);
            Name = "Form1";
            ShowIcon = false;
            Text = "Editor";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpen;
        private Button btnSave;
        private Button btnClose;
        private Button btnFont;
        private Button btnColor;
        private Button btnCustom;
        private RichTextBox rtbEditor;
    }
}
