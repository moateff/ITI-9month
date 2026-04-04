using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HotelManagementSystem.UI
{
    public partial class FoodMenu : MetroForm
    {
        #region Properties (Output)

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BreakfastQ { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LunchQ { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DinnerQ { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Cleaning { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Towel { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Surprise { get; private set; }

        #endregion

        #region Constructor

        public FoodMenu()
        {
            InitializeComponent();
            InitializeUI();
        }

        #endregion

        #region Initialization

        private void InitializeUI()
        {
            breakfastQTY.Enabled = false;
            lunchQTY.Enabled = false;
            dinnerQTY.Enabled = false;
        }

        #endregion

        #region Events

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!ReadInputs()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void breakfastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            breakfastQTY.Enabled = breakfastCheckBox.Checked;
        }

        private void lunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lunchQTY.Enabled = lunchCheckBox.Checked;
        }

        private void dinnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerQTY.Enabled = dinnerCheckBox.Checked;
        }

        #endregion

        #region Helpers

        private bool ReadInputs()
        {
            try
            {
                BreakfastQ = GetQuantity(breakfastCheckBox, breakfastQTY);
                LunchQ = GetQuantity(lunchCheckBox, lunchQTY);
                DinnerQ = GetQuantity(dinnerCheckBox, dinnerQTY);

                Cleaning = cleaningCheckBox.Checked;
                Towel = towelsCheckBox.Checked;
                Surprise = surpriseCheckBox.Checked;

                return true;
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(
                    this,
                    "Invalid quantity input. Please enter valid numbers.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
        }

        private int GetQuantity(CheckBox checkBox, Control control)
        {
            if (!checkBox.Checked)
                return 0;

            string valueText = control.Text;

            if (!int.TryParse(valueText, out int value) || value < 0)
                throw new Exception("Invalid number");

            return value;
        }

        #endregion
    }
}