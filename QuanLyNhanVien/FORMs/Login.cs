using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien.FORMs
{
    public partial class Login : Form
    {
        public static bool isThanhCong;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenDN = txtUser.Text;
            string pass = txtPass.Text;
            if (tenDN == "a" && pass == "a")
            {
                isThanhCong = true;
                MessageBox.Show("đăng nhập thành công");
                this.Close();
            }
            else
            {
                isThanhCong = false;
                MessageBox.Show("lỗi đăng nhập");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
