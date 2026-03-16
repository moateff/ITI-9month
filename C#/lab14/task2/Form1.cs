using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace task2
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;

        private DataTable titlesTable = new();
        private DataTable publishersTable = new();

        private BindingSource bindingSource = new();

        private BindingNavigator navigator;
        private ToolStripButton ButtonLoad;
        private ToolStripButton ButtonSave;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeNavigator();
            InitializeDatabase();
            LoadPublishers();
        }

        private void InitializeNavigator()
        {
            navigator =  new BindingNavigator(true)
            {
                Dock = DockStyle.Top,
                BindingSource = bindingSource
            };

            ButtonLoad = new ToolStripButton("Load");
            ButtonSave = new ToolStripButton("Save");

            ButtonLoad.Click += LoadData;
            ButtonSave.Click += SaveData;

            navigator.Items.Add(new ToolStripSeparator());
            navigator.Items.Add(ButtonLoad);
            navigator.Items.Add(ButtonSave);

            Controls.Add(navigator);
        }

        private void InitializeDatabase()
        {
            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["PubDbConnectionString"].ConnectionString;

                sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlcommand = new("SELECT * FROM titles", sqlConnection);

                sqlDataAdapter = new SqlDataAdapter(sqlcommand);

                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                SqlCommandBuilder builder = new(sqlDataAdapter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database initialization failed. " + ex.Message);
            }
        }

        private void LoadPublishers()
        {
            try
            {
                SqlCommand sqlCommand =
                    new("SELECT pub_id, pub_name FROM publishers", sqlConnection);

                SqlDataAdapter adapter = new(sqlCommand);

                adapter.Fill(publishersTable);

                comboBoxPublisher.DataSource = publishersTable;
                comboBoxPublisher.DisplayMember = "pub_name";
                comboBoxPublisher.ValueMember = "pub_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load publishers. " + ex.Message);
            }
        }

        private void LoadData(object sender, EventArgs e)
        {
            try
            {
                if (HasUnsavedChanges())
                    return;

                titlesTable.Clear();

                sqlDataAdapter.Fill(titlesTable);

                bindingSource.DataSource = titlesTable;

                BindControls();
                BindListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            try
            {
                bindingSource.EndEdit();

                if (titlesTable.GetChanges() == null)
                {
                    MessageBox.Show("No changes to save.");
                    return;
                }

                sqlDataAdapter.Update(titlesTable);

                titlesTable.AcceptChanges();

                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save changes. " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void BindControls()
        {
            textBoxTitleID.DataBindings.Clear();
            textBoxTitle.DataBindings.Clear();
            textBoxType.DataBindings.Clear();
            comboBoxPublisher.DataBindings.Clear();
            dateTimePickerDate.DataBindings.Clear();

            textBoxTitleID.DataBindings.Add("Text", bindingSource, "title_id");
            textBoxTitle.DataBindings.Add("Text", bindingSource, "title");
            textBoxType.DataBindings.Add("Text", bindingSource, "type");

            dateTimePickerDate.DataBindings.Add("Value", bindingSource, "pubdate");

            comboBoxPublisher.DataBindings.Add(
                "SelectedValue",
                bindingSource,
                "pub_id");
        }

        private void BindListBox()
        {
            listBoxTitle.DataSource = bindingSource;
            listBoxTitle.DisplayMember = "title";
            listBoxTitle.ValueMember = "title_id";
        }

        private bool HasUnsavedChanges()
        {
            if (titlesTable.GetChanges() == null)
                return false;

            DialogResult result = MessageBox.Show(
                "You have unsaved changes. Continue?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return result == DialogResult.No;
        }
    }
}
