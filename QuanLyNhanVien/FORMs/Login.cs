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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string tenDN = txtUser.Text;
            string pass = txtPass.Text;
            if (tenDN == "a" && pass == "a")
            {
                isThanhCong = true;
                MessageBox.Show("đăng nhập thành công");
                this.Hide();
                Form1 CT = new Form1();
                CT.Show();

            }
            else
            {
                isThanhCong = false;
                MessageBox.Show("lỗi đăng nhập");
            }
        }
    }
}
