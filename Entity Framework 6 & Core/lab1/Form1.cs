using System.Security.Cryptography;
using System.Web;

namespace lab13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.EndsWith(".rtf"))
                {
                    rtbEditor.LoadFile(ofd.FileName);
                }
                else
                {
                    rtbEditor.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.EndsWith(".rtf"))
                {
                    rtbEditor.SaveFile(sfd.FileName);
                }
                else
                {
                    File.WriteAllText(sfd.FileName, rtbEditor.Text);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();

            if (rtbEditor.SelectionFont != null)
            {
                fd.Font = rtbEditor.SelectionFont;
            }

            if (fd.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.SelectionFont = fd.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = rtbEditor.SelectionColor;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.SelectionColor = cd.Color;
            }
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            using (CustomDialog dlg = new CustomDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    rtbEditor.Text = dlg.TextContent;
                }
            }
        }
    }
}
