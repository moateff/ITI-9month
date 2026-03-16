namespace lab13
{
    partial class CustomDialog
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
            rtbDialog = new RichTextBox();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // rtbDialog
            // 
            rtbDialog.Location = new Point(12, 12);
            rtbDialog.Name = "rtbDialog";
            rtbDialog.Size = new Size(260, 87);
            rtbDialog.TabIndex = 0;
            rtbDialog.Text = "";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(39, 105);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(169, 105);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // CustomDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 134);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(rtbDialog);
            Name = "CustomDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "CustomDialog";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbDialog;
        private Button btnCancel;
        private Button btnOk;
    }
}