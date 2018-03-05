using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanVien.FORMs;
using QuanLyNhanVien.UCs;

namespace QuanLyNhanVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pic1 ucAnh = new Pic1();
            ucAnh.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(ucAnh);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frmDangNhap = new Login();
            frmDangNhap.ShowDialog();
            if (Login.isThanhCong)
            {
                try
                {
                    //DataTable dt = new DataTable();
                    //sqlQuery truyvanDL = new sqlQuery();
                    //dt = truyvanDL.LayDuLieu("SELECT * FROM SinhVien");
                    UCDSNV ucDS = new UCDSNV();
                    ucDS.Dock = DockStyle.Fill;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(ucDS);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
