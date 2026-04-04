using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HotelManagementSystem.UI
{
    public partial class FinalizePayment : MetroForm
    {
        #region Fields

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalAmountFromFrontend { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FoodBill { get; set; }

        private double _finalTotal;
        private string _paymentType = "";
        private string _cardNumber = "";
        private string _cardExpiry = "";
        private string _cardCvc = "";
        private string _cardType = "";

        #endregion

        #region Properties (Output)

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double FinalTotal => _finalTotal;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PaymentType => _paymentType;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PaymentCardNumber => _cardNumber;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CardExpiry => _cardExpiry;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CardCVC => _cardCvc;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CardType => _cardType;

        #endregion

        #region Constructor

        public FinalizePayment()
        {
            InitializeComponent();
            CenterToParent();
        }

        #endregion

        #region Load

        private void FinalizePayment_Load(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            double tax = TotalAmountFromFrontend * 0.07;
            _finalTotal = TotalAmountFromFrontend + tax + FoodBill;

            currentBillAmount.Text = $"${TotalAmountFromFrontend} USD";
            foodBillAmount.Text = $"${FoodBill} USD";
            taxAmount.Text = $"${tax} USD";
            totalAmount.Text = $"${_finalTotal} USD";
        }

        #endregion

        #region Events

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                _paymentType = paymentComboBox.Text;
                _cardNumber = phoneNComboBox.Text;
                _cardExpiry = $"{monthComboBox.SelectedItem}/{yearComboBox.SelectedItem}";
                _cardCvc = cvcComboBox.Text;
                _cardType = cardTypeView.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(
                    this,
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void phoneNComboBox_Leave(object sender, EventArgs e)
        {
            FormatCardNumber();
            DetectCardType();
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetectCardType();
        }

        #endregion

        #region Helpers

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(paymentComboBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNComboBox.Text) ||
                monthComboBox.SelectedItem == null ||
                yearComboBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(cvcComboBox.Text))
            {
                MetroFramework.MetroMessageBox.Show(
                    this,
                    "Please fill all payment fields",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private void FormatCardNumber()
        {
            if (long.TryParse(phoneNComboBox.Text.Replace("-", ""), out long number))
            {
                phoneNComboBox.Text = string.Format("{0:0000-0000-0000-0000}", number);
            }
        }

        private void DetectCardType()
        {
            if (string.IsNullOrEmpty(phoneNComboBox.Text)) return;

            char firstDigit = phoneNComboBox.Text.Replace("-", "")[0];

            _cardType = firstDigit switch
            {
                '3' => "American Express",
                '4' => "Visa",
                '5' => "MasterCard",
                '6' => "Discover",
                _ => "Unknown"
            };

            cardTypeView.Text = _cardType;
        }

        #endregion
    }
}