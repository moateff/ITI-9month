using BLL.Entities;
using BLL.EntityLists;
using BLL.EntityManagers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIL
{
    public partial class Form2 : Form
    {
        private TitleList titles;
        private PublisherList publishers;
        private BindingSource bindingSource = new();

        private BindingNavigator navigator;
        private ToolStripButton ButtonLoad;
        private ToolStripButton ButtonSave;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeNavigator();
            LoadPublishers();
            listBoxTitle.SelectedIndexChanged += ListBoxTitle_SelectedIndexChanged;
        }

        #region Navigator
        private void InitializeNavigator()
        {
            navigator = new BindingNavigator(true)
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
        #endregion

        #region Load Data
        private void LoadPublishers()
        {
            try
            {
                publishers = PublisherManager.SelectAllPublishers();

                comboBoxPublisher.DataSource = publishers;
                comboBoxPublisher.DisplayMember = "PubName";
                comboBoxPublisher.ValueMember = "PubID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load publishers: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(object sender, EventArgs e)
        {
            try
            {
                if (HasUnsavedChanges())
                    return;

                titles = TitleManager.SelectAllTitles();
                bindingSource.DataSource = titles;

                listBoxTitle.DataSource = bindingSource;
                listBoxTitle.DisplayMember = "TitleName";
                listBoxTitle.ValueMember = "TitleID";

                BindControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load titles: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Save Data
        private void SaveData(object sender, EventArgs e)
        {
            try
            {
                bindingSource.EndEdit();

                bool anyUpdated = false;

                foreach (var title in titles.ToList())
                {
                    if (string.IsNullOrWhiteSpace(title.TitleID))
                        continue;

                    switch (title.State)
                    {
                        case EntityState.Added:
                            if (TitleManager.InsertTitle(title))
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
                            if (TitleManager.DeleteTitle(title))
                            {
                                bindingSource.Remove(title);
                                anyUpdated = true;
                            }
                            break;
                    }
                }

                MessageBox.Show(anyUpdated ? "Changes saved successfully." : "No changes to save.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Bindings
        private void BindControls()
        {
            textBoxTitleID.DataBindings.Clear();
            textBoxTitle.DataBindings.Clear();
            textBoxType.DataBindings.Clear();
            comboBoxPublisher.DataBindings.Clear();
            dateTimePickerDate.DataBindings.Clear();

            textBoxTitleID.DataBindings.Add("Text", bindingSource, "TitleID");
            textBoxTitle.DataBindings.Add("Text", bindingSource, "TitleName");
            textBoxType.DataBindings.Add("Text", bindingSource, "Type");
            comboBoxPublisher.DataBindings.Add("SelectedValue", bindingSource, "PubID");
            dateTimePickerDate.DataBindings.Add("Value", bindingSource, "PubDate");
        }

        private void ListBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTitle.SelectedItem != null)
            {
                bindingSource.Position = listBoxTitle.SelectedIndex;
            }
        }
        #endregion

        #region Delete Handling
        private void listBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && bindingSource.Current is Title title)
            {
                title.State = EntityState.Deleted;
                e.Handled = true;
            }
        }
        #endregion

        #region Unsaved Changes
        private bool HasUnsavedChanges()
        {
            return titles != null && titles.Any(t => t.State != EntityState.Unchanged) &&
                   MessageBox.Show("You have unsaved changes. Continue?", "Warning",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No;
        }
        #endregion
    }
}