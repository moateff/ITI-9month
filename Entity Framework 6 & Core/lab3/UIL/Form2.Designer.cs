namespace UIL
{
    partial class Form2
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxTitle = new ListBox();
            textBoxType = new TextBox();
            textBoxTitle = new TextBox();
            textBoxTitleID = new TextBox();
            labelTilteID = new Label();
            labelTitle = new Label();
            labelType = new Label();
            labelPublisher = new Label();
            labelDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            comboBoxPublisher = new ComboBox();
            SuspendLayout();
            // 
            // listBoxTitle
            // 
            listBoxTitle.FormattingEnabled = true;
            listBoxTitle.Location = new Point(343, 12);
            listBoxTitle.Name = "listBoxTitle";
            listBoxTitle.Size = new Size(229, 289);
            listBoxTitle.TabIndex = 0;
            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(132, 144);
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(131, 23);
            textBoxType.TabIndex = 1;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(132, 115);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(131, 23);
            textBoxTitle.TabIndex = 2;
            // 
            // textBoxTitleID
            // 
            textBoxTitleID.Location = new Point(132, 86);
            textBoxTitleID.Name = "textBoxTitleID";
            textBoxTitleID.Size = new Size(131, 23);
            textBoxTitleID.TabIndex = 3;
            // 
            // labelTilteID
            // 
            labelTilteID.AutoSize = true;
            labelTilteID.Location = new Point(44, 89);
            labelTilteID.Name = "labelTilteID";
            labelTilteID.Size = new Size(43, 15);
            labelTilteID.TabIndex = 4;
            labelTilteID.Text = "Title ID";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(44, 118);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(29, 15);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Title";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(44, 147);
            labelType.Name = "labelType";
            labelType.Size = new Size(31, 15);
            labelType.TabIndex = 6;
            labelType.Text = "Type";
            // 
            // labelPublisher
            // 
            labelPublisher.AutoSize = true;
            labelPublisher.Location = new Point(44, 176);
            labelPublisher.Name = "labelPublisher";
            labelPublisher.Size = new Size(56, 15);
            labelPublisher.TabIndex = 7;
            labelPublisher.Text = "Publisher";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(44, 208);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(31, 15);
            labelDate.TabIndex = 8;
            labelDate.Text = "Date";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(132, 202);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(131, 23);
            dateTimePickerDate.TabIndex = 9;
            // 
            // comboBoxPublisher
            // 
            comboBoxPublisher.FormattingEnabled = true;
            comboBoxPublisher.Location = new Point(132, 173);
            comboBoxPublisher.Name = "comboBoxPublisher";
            comboBoxPublisher.Size = new Size(131, 23);
            comboBoxPublisher.TabIndex = 10;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(comboBoxPublisher);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelDate);
            Controls.Add(labelPublisher);
            Controls.Add(labelType);
            Controls.Add(labelTitle);
            Controls.Add(labelTilteID);
            Controls.Add(textBoxTitleID);
            Controls.Add(textBoxTitle);
            Controls.Add(textBoxType);
            Controls.Add(listBoxTitle);
            MinimumSize = new Size(600, 350);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxTitle;
        private TextBox textBoxType;
        private TextBox textBoxTitle;
        private TextBox textBoxTitleID;
        private Label labelTilteID;
        private Label labelTitle;
        private Label labelType;
        private Label labelPublisher;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate;
        private ComboBox comboBoxPublisher;
    }
}