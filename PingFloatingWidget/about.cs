using System;
using System.Windows.Forms;

namespace PingFloatingWidget
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bit.ly/PingFloatingWidget");
        }
    }
}
