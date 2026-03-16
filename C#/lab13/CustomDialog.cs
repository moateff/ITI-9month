using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab13
{
    public partial class CustomDialog : Form
    {
        public CustomDialog()
        {
            InitializeComponent();

            rtbDialog.Text = "";
        }

        public string TextContent { get { return rtbDialog.Text; } }
    }
}
