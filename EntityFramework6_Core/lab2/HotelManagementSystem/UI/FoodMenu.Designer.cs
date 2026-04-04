namespace HotelManagementSystem.UI
{
    partial class FoodMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodMenu));
            foodPanel = new MetroFramework.Controls.MetroPanel();
            dinnerQTY = new MetroFramework.Controls.MetroTextBox();
            lunchQTY = new MetroFramework.Controls.MetroTextBox();
            breakfastQTY = new MetroFramework.Controls.MetroTextBox();
            dinnerPicture = new PictureBox();
            lunchPicture = new PictureBox();
            breakfastPicture = new PictureBox();
            dinnerCheckBox = new MetroFramework.Controls.MetroCheckBox();
            lunchCheckBox = new MetroFramework.Controls.MetroCheckBox();
            breakfastCheckBox = new MetroFramework.Controls.MetroCheckBox();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            needPanel = new MetroFramework.Controls.MetroPanel();
            surpriseCheckBox = new MetroFramework.Controls.MetroCheckBox();
            towelsCheckBox = new MetroFramework.Controls.MetroCheckBox();
            cleaningCheckBox = new MetroFramework.Controls.MetroCheckBox();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            nextButton = new MetroFramework.Controls.MetroButton();
            foodPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dinnerPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lunchPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakfastPicture).BeginInit();
            needPanel.SuspendLayout();
            SuspendLayout();
            // 
            // foodPanel
            // 
            foodPanel.BackColor = Color.FromArgb(225, 225, 225);
            foodPanel.BackgroundImageLayout = ImageLayout.None;
            foodPanel.Controls.Add(dinnerQTY);
            foodPanel.Controls.Add(lunchQTY);
            foodPanel.Controls.Add(breakfastQTY);
            foodPanel.Controls.Add(dinnerPicture);
            foodPanel.Controls.Add(lunchPicture);
            foodPanel.Controls.Add(breakfastPicture);
            foodPanel.Controls.Add(dinnerCheckBox);
            foodPanel.Controls.Add(lunchCheckBox);
            foodPanel.Controls.Add(breakfastCheckBox);
            foodPanel.Controls.Add(metroLabel1);
            foodPanel.HorizontalScrollbarBarColor = true;
            foodPanel.HorizontalScrollbarHighlightOnWheel = false;
            foodPanel.HorizontalScrollbarSize = 12;
            foodPanel.Location = new Point(16, 73);
            foodPanel.Margin = new Padding(4, 3, 4, 3);
            foodPanel.Name = "foodPanel";
            foodPanel.Size = new Size(387, 423);
            foodPanel.TabIndex = 5;
            foodPanel.UseCustomBackColor = true;
            foodPanel.UseCustomForeColor = true;
            foodPanel.UseStyleColors = true;
            foodPanel.VerticalScrollbarBarColor = true;
            foodPanel.VerticalScrollbarHighlightOnWheel = false;
            foodPanel.VerticalScrollbarSize = 12;
            // 
            // dinnerQTY
            // 
            dinnerQTY.BackColor = Color.White;
            dinnerQTY.Enabled = false;
            dinnerQTY.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            dinnerQTY.Location = new Point(16, 377);
            dinnerQTY.Margin = new Padding(4, 3, 4, 3);
            dinnerQTY.MaxLength = 32767;
            dinnerQTY.Name = "dinnerQTY";
            dinnerQTY.PasswordChar = '\0';
            dinnerQTY.PromptText = "Quantity ?";
            dinnerQTY.ScrollBars = ScrollBars.None;
            dinnerQTY.SelectedText = "";
            dinnerQTY.Size = new Size(150, 33);
            dinnerQTY.Style = MetroFramework.MetroColorStyle.White;
            dinnerQTY.TabIndex = 40;
            dinnerQTY.UseCustomBackColor = true;
            dinnerQTY.UseSelectable = true;
            // 
            // lunchQTY
            // 
            lunchQTY.BackColor = Color.White;
            lunchQTY.Enabled = false;
            lunchQTY.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            lunchQTY.Location = new Point(201, 209);
            lunchQTY.Margin = new Padding(4, 3, 4, 3);
            lunchQTY.MaxLength = 32767;
            lunchQTY.Name = "lunchQTY";
            lunchQTY.PasswordChar = '\0';
            lunchQTY.PromptText = "Quantity ?";
            lunchQTY.ScrollBars = ScrollBars.None;
            lunchQTY.SelectedText = "";
            lunchQTY.Size = new Size(168, 33);
            lunchQTY.Style = MetroFramework.MetroColorStyle.White;
            lunchQTY.TabIndex = 39;
            lunchQTY.UseCustomBackColor = true;
            lunchQTY.UseSelectable = true;
            // 
            // breakfastQTY
            // 
            breakfastQTY.BackColor = Color.White;
            breakfastQTY.Enabled = false;
            breakfastQTY.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            breakfastQTY.Location = new Point(16, 209);
            breakfastQTY.Margin = new Padding(4, 3, 4, 3);
            breakfastQTY.MaxLength = 32767;
            breakfastQTY.Name = "breakfastQTY";
            breakfastQTY.PasswordChar = '\0';
            breakfastQTY.PromptText = "Quantity ?";
            breakfastQTY.ScrollBars = ScrollBars.None;
            breakfastQTY.SelectedText = "";
            breakfastQTY.Size = new Size(150, 33);
            breakfastQTY.Style = MetroFramework.MetroColorStyle.White;
            breakfastQTY.TabIndex = 38;
            breakfastQTY.UseCustomBackColor = true;
            breakfastQTY.UseSelectable = true;
            // 
            // dinnerPicture
            // 
            dinnerPicture.Image = (Image)resources.GetObject("dinnerPicture.Image");
            dinnerPicture.Location = new Point(16, 261);
            dinnerPicture.Margin = new Padding(4, 3, 4, 3);
            dinnerPicture.Name = "dinnerPicture";
            dinnerPicture.Size = new Size(150, 87);
            dinnerPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            dinnerPicture.TabIndex = 8;
            dinnerPicture.TabStop = false;
            // 
            // lunchPicture
            // 
            lunchPicture.Image = (Image)resources.GetObject("lunchPicture.Image");
            lunchPicture.Location = new Point(201, 63);
            lunchPicture.Margin = new Padding(4, 3, 4, 3);
            lunchPicture.Name = "lunchPicture";
            lunchPicture.Size = new Size(168, 106);
            lunchPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            lunchPicture.TabIndex = 7;
            lunchPicture.TabStop = false;
            // 
            // breakfastPicture
            // 
            breakfastPicture.Image = (Image)resources.GetObject("breakfastPicture.Image");
            breakfastPicture.Location = new Point(16, 63);
            breakfastPicture.Margin = new Padding(4, 3, 4, 3);
            breakfastPicture.Name = "breakfastPicture";
            breakfastPicture.Size = new Size(150, 106);
            breakfastPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakfastPicture.TabIndex = 6;
            breakfastPicture.TabStop = false;
            // 
            // dinnerCheckBox
            // 
            dinnerCheckBox.AutoSize = true;
            dinnerCheckBox.BackColor = Color.Transparent;
            dinnerCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            dinnerCheckBox.Location = new Point(16, 354);
            dinnerCheckBox.Margin = new Padding(4, 3, 4, 3);
            dinnerCheckBox.Name = "dinnerCheckBox";
            dinnerCheckBox.Size = new Size(110, 19);
            dinnerCheckBox.TabIndex = 5;
            dinnerCheckBox.Text = "Dinner   ($15)";
            dinnerCheckBox.UseCustomBackColor = true;
            dinnerCheckBox.UseSelectable = true;
            dinnerCheckBox.UseVisualStyleBackColor = false;
            dinnerCheckBox.CheckedChanged += dinnerCheckBox_CheckedChanged;
            // 
            // lunchCheckBox
            // 
            lunchCheckBox.AutoSize = true;
            lunchCheckBox.BackColor = Color.Transparent;
            lunchCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            lunchCheckBox.Location = new Point(201, 180);
            lunchCheckBox.Margin = new Padding(4, 3, 4, 3);
            lunchCheckBox.Name = "lunchCheckBox";
            lunchCheckBox.Size = new Size(106, 19);
            lunchCheckBox.TabIndex = 4;
            lunchCheckBox.Text = "Lunch   ($15)";
            lunchCheckBox.UseCustomBackColor = true;
            lunchCheckBox.UseSelectable = true;
            lunchCheckBox.UseVisualStyleBackColor = false;
            lunchCheckBox.CheckedChanged += lunchCheckBox_CheckedChanged;
            // 
            // breakfastCheckBox
            // 
            breakfastCheckBox.AutoSize = true;
            breakfastCheckBox.BackColor = Color.Transparent;
            breakfastCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            breakfastCheckBox.Location = new Point(16, 180);
            breakfastCheckBox.Margin = new Padding(4, 3, 4, 3);
            breakfastCheckBox.Name = "breakfastCheckBox";
            breakfastCheckBox.Size = new Size(120, 19);
            breakfastCheckBox.TabIndex = 3;
            breakfastCheckBox.Text = "Break Fast  ($7)";
            breakfastCheckBox.UseCustomBackColor = true;
            breakfastCheckBox.UseSelectable = true;
            breakfastCheckBox.UseVisualStyleBackColor = false;
            breakfastCheckBox.CheckedChanged += breakfastCheckBox_CheckedChanged;
            // 
            // metroLabel1
            // 
            metroLabel1.BackColor = Color.Transparent;
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel1.Location = new Point(4, 12);
            metroLabel1.Margin = new Padding(4, 0, 4, 0);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(202, 32);
            metroLabel1.TabIndex = 2;
            metroLabel1.Text = "Food Selection";
            metroLabel1.UseCustomBackColor = true;
            // 
            // needPanel
            // 
            needPanel.BackColor = Color.FromArgb(225, 225, 225);
            needPanel.BackgroundImageLayout = ImageLayout.None;
            needPanel.Controls.Add(surpriseCheckBox);
            needPanel.Controls.Add(towelsCheckBox);
            needPanel.Controls.Add(cleaningCheckBox);
            needPanel.Controls.Add(metroLabel2);
            needPanel.HorizontalScrollbarBarColor = true;
            needPanel.HorizontalScrollbarHighlightOnWheel = false;
            needPanel.HorizontalScrollbarSize = 12;
            needPanel.Location = new Point(414, 73);
            needPanel.Margin = new Padding(4, 3, 4, 3);
            needPanel.Name = "needPanel";
            needPanel.Size = new Size(191, 376);
            needPanel.TabIndex = 6;
            needPanel.UseCustomBackColor = true;
            needPanel.UseCustomForeColor = true;
            needPanel.UseStyleColors = true;
            needPanel.VerticalScrollbarBarColor = true;
            needPanel.VerticalScrollbarHighlightOnWheel = false;
            needPanel.VerticalScrollbarSize = 12;
            // 
            // surpriseCheckBox
            // 
            surpriseCheckBox.AutoSize = true;
            surpriseCheckBox.BackColor = Color.Transparent;
            surpriseCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            surpriseCheckBox.Location = new Point(21, 148);
            surpriseCheckBox.Margin = new Padding(4, 3, 4, 3);
            surpriseCheckBox.Name = "surpriseCheckBox";
            surpriseCheckBox.Size = new Size(131, 19);
            surpriseCheckBox.TabIndex = 44;
            surpriseCheckBox.Text = "Sweetest surprise";
            surpriseCheckBox.UseCustomBackColor = true;
            surpriseCheckBox.UseSelectable = true;
            surpriseCheckBox.UseVisualStyleBackColor = false;
            // 
            // towelsCheckBox
            // 
            towelsCheckBox.AutoSize = true;
            towelsCheckBox.BackColor = Color.Transparent;
            towelsCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            towelsCheckBox.Location = new Point(21, 105);
            towelsCheckBox.Margin = new Padding(4, 3, 4, 3);
            towelsCheckBox.Name = "towelsCheckBox";
            towelsCheckBox.Size = new Size(65, 19);
            towelsCheckBox.TabIndex = 42;
            towelsCheckBox.Text = "Towels";
            towelsCheckBox.UseCustomBackColor = true;
            towelsCheckBox.UseSelectable = true;
            towelsCheckBox.UseVisualStyleBackColor = false;
            // 
            // cleaningCheckBox
            // 
            cleaningCheckBox.AutoSize = true;
            cleaningCheckBox.BackColor = Color.Transparent;
            cleaningCheckBox.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            cleaningCheckBox.Location = new Point(21, 63);
            cleaningCheckBox.Margin = new Padding(4, 3, 4, 3);
            cleaningCheckBox.Name = "cleaningCheckBox";
            cleaningCheckBox.Size = new Size(78, 19);
            cleaningCheckBox.TabIndex = 41;
            cleaningCheckBox.Text = "Cleaning";
            cleaningCheckBox.UseCustomBackColor = true;
            cleaningCheckBox.UseSelectable = true;
            cleaningCheckBox.UseVisualStyleBackColor = false;
            // 
            // metroLabel2
            // 
            metroLabel2.BackColor = Color.Transparent;
            metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel2.Location = new Point(4, 12);
            metroLabel2.Margin = new Padding(4, 0, 4, 0);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(141, 32);
            metroLabel2.TabIndex = 41;
            metroLabel2.Text = "Special needs";
            metroLabel2.UseCustomBackColor = true;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(414, 457);
            nextButton.Margin = new Padding(4, 3, 4, 3);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(191, 39);
            nextButton.TabIndex = 45;
            nextButton.Text = "Next";
            nextButton.UseSelectable = true;
            nextButton.Click += nextButton_Click;
            // 
            // FoodMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 519);
            Controls.Add(nextButton);
            Controls.Add(needPanel);
            Controls.Add(foodPanel);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FoodMenu";
            Padding = new Padding(23, 69, 23, 23);
            Resizable = false;
            ShowInTaskbar = false;
            Text = "Food and Menu";
            foodPanel.ResumeLayout(false);
            foodPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dinnerPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)lunchPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakfastPicture).EndInit();
            needPanel.ResumeLayout(false);
            needPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel foodPanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox dinnerPicture;
        private System.Windows.Forms.PictureBox lunchPicture;
        private System.Windows.Forms.PictureBox breakfastPicture;
        public MetroFramework.Controls.MetroTextBox breakfastQTY;
        public MetroFramework.Controls.MetroTextBox dinnerQTY;
        public MetroFramework.Controls.MetroTextBox lunchQTY;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroCheckBox dinnerCheckBox;
        public MetroFramework.Controls.MetroCheckBox lunchCheckBox;
        public MetroFramework.Controls.MetroCheckBox breakfastCheckBox;
        public MetroFramework.Controls.MetroCheckBox surpriseCheckBox;
        public MetroFramework.Controls.MetroCheckBox towelsCheckBox;
        public MetroFramework.Controls.MetroCheckBox cleaningCheckBox;
        public MetroFramework.Controls.MetroButton nextButton;
        public MetroFramework.Controls.MetroPanel needPanel;
    }
}