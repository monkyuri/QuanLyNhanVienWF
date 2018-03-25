using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucNhanVien nv = new ucNhanVien();
            panel1.Controls.Clear();
            panel1.Controls.Add(nv);
            nv.Dock = DockStyle.Fill;
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucPhongBan nv = new ucPhongBan();
            panel1.Controls.Clear();
            panel1.Controls.Add(nv);
            nv.Dock = DockStyle.Fill;
        }
    }
}
