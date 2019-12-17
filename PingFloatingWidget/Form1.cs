using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingFloatingWidget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Threading.Timer threadingTimer;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(64, 32);
            this.MaximumSize = new Size(64, 32);
            threadingTimer = new System.Threading.Timer(pingResult, 10, 1, 1000);
        }

        //Get ping and put it in label1
        static string ipAddress = "www.google.com";
        private string pingValue;
        private string PingValue
        {
            get { return pingValue; }
            set
            {
                pingValue = value;
                refreshPing();
            }
        }
        delegate void refreshPingdelegate();
        void refreshPing()
        {
            if (label1.InvokeRequired)
            {
                refreshPingdelegate rpd = new refreshPingdelegate(refreshPing);
                this.Invoke(rpd, new object[] { });
            }
            else
            {
                label1.Text = PingValue;
            }
        }
        private void pingResult(object state)
        {
            Ping ping = new Ping();
            PingReply pingReply;
            try
            {
                pingReply = ping.Send(ipAddress);
                if (pingReply.Status == IPStatus.Success)
                {
                    PingValue = pingReply.RoundtripTime.ToString() + " ms";
                }
                else
                {
                    throw new PingException(pingReply.Status.ToString());
                }
            }
            catch (PingException e)
            {
                PingValue = e.Message;
            }
        }
        //end

        // FORM MOVABLE
        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        // End

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // IP Changer
        private void IPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IP().ShowDialog();
        }

        static public void setS(string IP)
        {
            ipAddress = IP;
        }

        static public string getS()
        {
            return ipAddress;
        }

        // Color Changer
        ColorDialog colorDlg = new ColorDialog();
        private void ChangeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                label1.BackColor = colorDlg.Color;
                label1.ForeColor = Color.FromArgb(colorDlg.Color.ToArgb() ^ 0xffffff);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new about().ShowDialog();
        }

    }
}
