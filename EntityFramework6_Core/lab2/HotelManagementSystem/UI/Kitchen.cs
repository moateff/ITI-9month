using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Context.FrontendReservation;
using HotelManagementSystem.Entities.FrontendReservation;

namespace HotelManagementSystem.UI
{
    public partial class Kitchen : MetroForm
    {
        private readonly FrontendReservationContext _context = new();
        private readonly BindingSource _bindingSource = new();

        private int _breakfast, _lunch, _dinner, _foodBill;
        private double _totalBill;
        private int _selectedId = -1;

        public Kitchen()
        {
            InitializeComponent();
        }

        private void kitchen_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadQueue();
        }

        #region Load Data

        private void LoadGrid()
        {
            try
            {
                _context.ChangeTracker.Clear();

                _context.Reservations
                    .Where(r => r.CheckIn && !r.SupplyStatus)
                    .Load();

                _bindingSource.DataSource = _context.Reservations.Local.ToBindingList();
                overviewDataGridView.DataSource = _bindingSource;

                HideColumns();
            }
            catch (Exception ex)
            {
                ShowError("Error loading grid", ex);
            }
        }

        private void LoadQueue()
        {
            try
            {
                queueListBox.Items.Clear();

                var data = _context.Reservations
                    .Where(r => r.CheckIn && !r.SupplyStatus)
                    .AsNoTracking()
                    .ToList();

                foreach (var r in data)
                {
                    queueListBox.Items.Add($"{r.Id} | {r.FirstName} {r.LastName} | {r.PhoneNumber}");
                }
            }
            catch (Exception ex)
            {
                ShowError("Error loading queue", ex);
            }
        }

        private void HideColumns()
        {
            string[] hidden =
            {
                "BirthDay","Gender","Email","AptSuite","NumberGuest","StreetAddress",
                "City","State","ZipCode","PaymentType","CardType","CardNumber",
                "CardExp","CardCvc","ArrivalTime","LeavingTime","CheckIn"
            };

            foreach (var col in hidden)
            {
                var column = overviewDataGridView.Columns[col];
                if (column != null)
                    column.Visible = false;
            }
        }

        #endregion

        #region Grid Defaults

        private void overviewDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["CheckIn"].Value = true;
            e.Row.Cells["SupplyStatus"].Value = false;
            e.Row.Cells["BreakFast"].Value = 0;
            e.Row.Cells["Lunch"].Value = 0;
            e.Row.Cells["Dinner"].Value = 0;
            e.Row.Cells["FoodBill"].Value = 0;
            e.Row.Cells["TotalBill"].Value = 0;
        }

        #endregion

        #region Selection

        private void queueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (queueListBox.SelectedItem == null) return;

            try
            {
                ResetInputs();

                _selectedId = int.Parse(queueListBox.Text.Split(' ')[0]);

                var r = _context.Reservations.FirstOrDefault(x => x.Id == _selectedId);
                if (r == null) return;

                FillForm(r);
            }
            catch (Exception ex)
            {
                ShowError("Selection error", ex);
            }
        }

        private void FillForm(Reservation r)
        {
            firstNameTextBox.Text = r.FirstName;
            lastNameTextBox.Text = r.LastName;
            phoneNTextBox.Text = r.PhoneNumber;
            roomTypeTextBox.Text = r.RoomType;
            floorNTextBox.Text = r.RoomFloor;
            roomNTextBox.Text = r.RoomNumber;

            cleaningCheckBox.Checked = r.Cleaning;
            towelCheckBox.Checked = r.Towel;
            surpriseCheckBox.Checked = r.SSurprise;
            supplyCheckBox.Checked = r.SupplyStatus;

            _breakfast = r.BreakFast;
            _lunch = r.Lunch;
            _dinner = r.Dinner;

            breakfastTextBox.Text = _breakfast > 0 ? _breakfast.ToString() : "NONE";
            lunchTextBox.Text = _lunch > 0 ? _lunch.ToString() : "NONE";
            dinnerTextBox.Text = _dinner > 0 ? _dinner.ToString() : "NONE";

            _foodBill = r.FoodBill;
            _totalBill = (r.TotalBill) - _foodBill;
        }

        #endregion

        #region Update (Single Save Point)

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                overviewDataGridView.EndEdit();
                _bindingSource.EndEdit();

                ValidateNewRows();

                var r = _context.Reservations.FirstOrDefault(x => x.Id == _selectedId);
                if (r != null)
                {
                    r.TotalBill = _totalBill + _foodBill;
                    r.BreakFast = _breakfast;
                    r.Lunch = _lunch;
                    r.Dinner = _dinner;
                    r.SupplyStatus = supplyCheckBox.Checked;
                    r.Cleaning = cleaningCheckBox.Checked;
                    r.Towel = towelCheckBox.Checked;
                    r.SSurprise = surpriseCheckBox.Checked;
                    r.FoodBill = _foodBill;
                }

                _context.SaveChanges();

                MessageBox.Show("Changes saved successfully");

                ReloadUI();
            }
            catch (Exception ex)
            {
                ShowError("Save failed", ex);
            }
        }

        private void ValidateNewRows()
        {
            foreach (var entry in _context.ChangeTracker.Entries<Reservation>())
            {
                if (entry.State == EntityState.Added)
                {
                    var r = entry.Entity;

                    if (string.IsNullOrWhiteSpace(r.FirstName))
                        throw new Exception("First Name is required");

                    if (string.IsNullOrWhiteSpace(r.LastName))
                        throw new Exception("Last Name is required");

                    if (string.IsNullOrWhiteSpace(r.PhoneNumber))
                        throw new Exception("Phone Number is required");
                }
            }
        }

        #endregion

        #region Food

        private void foodSelectionButton_Click(object sender, EventArgs e)
        {
            var food = new FoodMenu { needPanel = { Visible = false } };
            food.ShowDialog();

            _breakfast = food.BreakfastQ;
            _lunch = food.LunchQ;
            _dinner = food.DinnerQ;

            _foodBill += (_breakfast * 7) + (_lunch * 15) + (_dinner * 15);
        }

        #endregion

        #region Helpers

        private void ReloadUI()
        {
            LoadGrid();
            LoadQueue();
            ResetInputs();
        }

        private void ResetInputs()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox tb) tb.Clear();
            }
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"{title}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void supplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cleaningCheckBox.Checked = false;
            towelCheckBox.Checked = false;
            surpriseCheckBox.Checked = false;
        }

        private void kitchen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}