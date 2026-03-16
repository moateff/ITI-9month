using BLL.Entities;
using BLL.EntityLists;
using BLL.EntityManagers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UIL
{
    public partial class Form1 : Form
    {
        private TitleList _titles;
        private BindingSource _bindingSource = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.UserDeletingRow += OnDeleteItem;
            dataGridView.RowPrePaint += DataGridView_RowPrePaint;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _titles = TitleManager.SelectAllTitles();
                _bindingSource.DataSource = _titles;
                dataGridView.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(), 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _bindingSource.EndEdit();
                dataGridView.EndEdit();

                bool anyUpdated = false;

                foreach (var title in _titles.ToList()) // ToList to safely iterate while modifying
                {
                    if (string.IsNullOrWhiteSpace(title.TitleID))
                        continue;

                    switch (title.State)
                    {
                        case EntityState.Added:
                            if (title.State != EntityState.Deleted && TitleManager.InsertTitle(title))
                            {
                                title.State = EntityState.Unchanged;
                                anyUpdated = true;
                            }
                            break;

                        case EntityState.Modified:
                            if (TitleManager.UpdateTitle(title))
                            {
                                title.State = EntityState.Unchanged;
                                anyUpdated = true;
                            }
                            break;

                        case EntityState.Deleted:
                            if (title.State != EntityState.Added && TitleManager.DeleteTitle(title))
                            {
                                _bindingSource.Remove(title);
                                anyUpdated = true;
                            }
                            break;
                    }
                }

                MessageBox.Show(anyUpdated ? "Changes saved successfully." : "No changes to save.");

                dataGridView.Refresh(); // Update row color immediately
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(), 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void OnDeleteItem(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true; // Prevent actual row deletion

            if (_bindingSource.Current is Title title)
            {
                title.State = EntityState.Deleted;
                dataGridView.Refresh(); // Update row color immediately
            }
        }

        // Optional: Visual cues for row states
        private void DataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].DataBoundItem is Title title)
            {
                switch (title.State)
                {
                    case EntityState.Added:
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                        break;
                    case EntityState.Modified:
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case EntityState.Deleted:
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Coral;
                        break;
                    default:
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }
            }
        }
    }
}