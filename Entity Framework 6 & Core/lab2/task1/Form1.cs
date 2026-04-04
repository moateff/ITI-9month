using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace task1
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["PubDbConnectionString"].ConnectionString;

                sqlConnection = new SqlConnection(connectionString);

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM titles", sqlConnection);

                sqlDataAdapter = new SqlDataAdapter(selectCommand);

                // Important: load schema including primary key
                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataTable = new DataTable();

                bindingSource = new BindingSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database initialization failed. " + ex.Message);
                menuStrip1.Enabled = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable.GetChanges() != null)
                {
                    DialogResult result = MessageBox.Show(
                        "You have unsaved changes. Continue?",
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                        return;
                }

                dataTable.Clear();

                sqlDataAdapter.Fill(dataTable);

                bindingSource.DataSource = dataTable;

                dataGridView1.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource.EndEdit(); //

                dataGridView1.EndEdit(); //

                if (dataTable.GetChanges() == null)
                {
                    MessageBox.Show("No changes to save.");
                    return;
                }

                sqlDataAdapter.Update(dataTable);

                dataTable.AcceptChanges(); //
                
                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save changes. " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
