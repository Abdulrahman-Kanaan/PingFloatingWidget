using System;
using System.Windows.Forms;

namespace PingFloatingWidget
{
    public partial class IP : Form
    {
        public IP()
        {
            InitializeComponent();
        }

        private void IP_Load(object sender, EventArgs e)
        {
            currentIP.Text = Form1.getS();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s = IpText.Text.ToString();
            Form1.setS(s);
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IpText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string s = IpText.Text.ToString();
                Form1.setS(s);
                this.Close();
            }
        }
    }
}
