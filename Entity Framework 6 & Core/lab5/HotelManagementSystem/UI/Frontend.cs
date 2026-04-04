using Dapper;
using HotelManagementSystem.Context.FrontendReservation;
using MetroFramework.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.UI
{
    public partial class Frontend : MetroForm
    {
        #region Fields

        private readonly FrontendReservationContext _context = new();

        private int primaryID;
        private int breakfast, lunch, dinner;
        private int foodBill, totalAmount, foodStatus, checkin;
        private double finalizedTotalAmount;

        private string paymentType = "", paymentCardNumber = "", MM_YY_Of_Card = "", CVC_Of_Card = "";

        #endregion

        #region Constructor

        public Frontend()
        {
            InitializeComponent();
            InitializeUI();
            LoadInitialData();
        }

        #endregion

        #region Initialization

        private void InitializeUI()
        {
            CenterToScreen();
            entryDatePicker.MinDate = DateTime.Today;
            depDatePicker.MinDate = DateTime.Today.AddDays(1);

            roomOccupiedListBox.DrawMode = DrawMode.OwnerDrawFixed;
            roomReservedListBox.DrawMode = DrawMode.OwnerDrawFixed;

            roomOccupiedListBox.DrawItem += DrawListBoxItem;
            roomReservedListBox.DrawItem += DrawListBoxItem;
        }

        private void LoadInitialData()
        {
            LoadGrid();
            LoadReservationsToCombo();
            LoadOccupiedRooms();
            LoadReservedRooms();
            RemoveTakenRooms();
        }

        #endregion

        #region UI Helpers

        private void DrawListBoxItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || sender is not ListBox lb) return;

            e.DrawBackground();
            e.Graphics.DrawString(
                lb.Items[e.Index].ToString(),
                new Font("Segoe UI", 11),
                Brushes.Black,
                e.Bounds
            );
        }

        private void ResetForm()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox t) t.Clear();
                if (c is ComboBox cb) cb.SelectedIndex = -1;
            }

            checkinCheckBox.Checked = false;
            foodSupplyCheckBox.Checked = false;

            breakfast = lunch = dinner = foodBill = 0;
            // cleaning = "0";
        }

        #endregion

        #region Database (Dapper Reads)

        private DbConnection GetConnection()
            => _context.Database.GetDbConnection();

        private void LoadGrid()
        {
            var data = GetConnection()
                .Query("SELECT * FROM reservations")
                .ToList();

            resTotalDataGridView.DataSource = data;
        }

        private void LoadReservationsToCombo()
        {
            resEditButton.Items.Clear();

            var data = GetConnection()
                .Query("SELECT Id, FirstName, LastName, PhoneNumber FROM reservations");

            foreach (var r in data)
            {
                resEditButton.Items.Add($"{r.Id} | {r.FirstName} {r.LastName} | {r.PhoneNumber}");
            }
        }

        private void LoadOccupiedRooms()
        {
            roomOccupiedListBox.Items.Clear();

            var rooms = GetConnection()
                .Query("SELECT RoomNumber, RoomType, Id, FirstName, LastName FROM reservations WHERE CheckIn = 1");

            foreach (var r in rooms)
            {
                roomOccupiedListBox.Items.Add($"[{r.RoomNumber}] {r.RoomType} {r.Id} [{r.FirstName} {r.LastName}]");
            }
        }

        private void LoadReservedRooms()
        {
            roomReservedListBox.Items.Clear();

            var rooms = GetConnection()
                .Query("SELECT RoomNumber, RoomType, Id, FirstName, LastName FROM reservations WHERE CheckIn = 0");

            foreach (var r in rooms)
            {
                roomReservedListBox.Items.Add($"[{r.RoomNumber}] {r.RoomType} {r.Id} [{r.FirstName} {r.LastName}]");
            }
        }

        private void RemoveTakenRooms()
        {
            var taken = GetConnection()
                .Query<string>("SELECT RoomNumber FROM reservations WHERE CheckIn = 1")
                .ToList();

            foreach (var r in taken)
            {
                if (roomNComboBox.Items.Contains(r))
                    roomNComboBox.Items.Remove(r);
            }
        }

        #endregion

        #region CRUD (EF Writes)

        private void submitButton_Click(object sender, EventArgs e)
        {
            finalizedTotalAmount = totalAmount + foodBill;

            var entity = new Entities.FrontendReservation.Reservation
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text,
                EmailAddress = emailTextBox.Text,
                RoomNumber = roomNComboBox.Text,
                RoomType = roomTypeComboBox.Text,
                RoomFloor = floorComboBox.Text,
                TotalBill = finalizedTotalAmount,
                PaymentType = paymentType,
                CardNumber = paymentCardNumber,
                CardExp = MM_YY_Of_Card,
                CardCvc = CVC_Of_Card,
                CheckIn = checkin == 1,
                BreakFast = breakfast,
                Lunch = lunch,
                Dinner = dinner,
                FoodBill = foodBill
            };

            _context.Reservations.Add(entity);
            _context.SaveChanges();

            MessageBox.Show("Inserted successfully");

            RefreshAll();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var r = _context.Reservations.FirstOrDefault(x => x.Id == primaryID);
            if (r == null) return;

            r.FirstName = firstNameTextBox.Text;
            r.LastName = lastNameTextBox.Text;
            r.PhoneNumber = phoneNumberTextBox.Text;
            r.TotalBill = finalizedTotalAmount;

            _context.SaveChanges();

            MessageBox.Show("Updated successfully");

            RefreshAll();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var r = _context.Reservations.FirstOrDefault(x => x.Id == primaryID);
            if (r == null) return;

            _context.Reservations.Remove(r);
            _context.SaveChanges();

            MessageBox.Show("Deleted successfully");

            RefreshAll();
        }

        #endregion

        #region Events

        private void newButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // Enable edit mode
            updateButton.Enabled = true;
            deleteButton.Enabled = true;
            submitButton.Enabled = false;
        }

        private void foodMenuButton_Click(object sender, EventArgs e)
        {
            var foodMenu = new FoodMenu();
            foodMenu.ShowDialog();
        }

        private void finalizeButton_Click(object sender, EventArgs e)
        {
            var finalizePayment = new FinalizePayment();
            finalizePayment.ShowDialog();
        }

        private void phoneNumberTextBox_Leave(object sender, EventArgs e)
        {
            // Basic phone number validation
            if (!string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) && phoneNumberTextBox.Text.Length < 10)
            {
                MessageBox.Show("Please enter a valid phone number.");
                phoneNumberTextBox.Focus();
            }
        }

        private void frontend_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Optional: save any unsaved data or confirm exit
        }

        private void MainTab_Load(object sender, EventArgs e)
        {
            // Load initial data if needed
            LoadInitialData();
        }

        private void roomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalAmount = roomTypeComboBox.Text switch
            {
                "Single" => 149,
                "Double" => 299,
                "Twin" => 349,
                "Duplex" => 399,
                "Suite" => 499,
                _ => 0
            };
        }

        private void checkinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkin = checkinCheckBox.Checked ? 1 : 0;
        }

        private void foodSupplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foodStatus = foodSupplyCheckBox.Checked ? 1 : 0;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var result = GetConnection().Query(@"
                SELECT * FROM reservations
                WHERE FirstName LIKE @q OR LastName LIKE @q OR PhoneNumber LIKE @q",
                new { q = "%" + searchTextBox.Text + "%" });

            searchDataGridView.DataSource = result.ToList();
        }

        private void resEditButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(resEditButton.Text)) return;

            var id = int.Parse(resEditButton.Text.Split('|')[0].Trim());

            var r = GetConnection()
                .QueryFirstOrDefault("SELECT * FROM reservations WHERE Id = @id", new { id });

            if (r == null) return;

            primaryID = id;
            firstNameTextBox.Text = r.FirstName;
            lastNameTextBox.Text = r.LastName;
            phoneNumberTextBox.Text = r.PhoneNumber;
        }

        #endregion

        #region Helpers

        private void RefreshAll()
        {
            ResetForm();
            LoadInitialData();
        }

        #endregion
    }
}