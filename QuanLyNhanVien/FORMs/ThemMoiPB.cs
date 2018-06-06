using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanVien
{
    public partial class ThemMoiPB : Form
    {
        public ThemMoiPB()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string them = "insert into PhongBan values ('" + txtMaPB.Text.Trim() + "', N'" + txtTenPB.Text.Trim() + "', '" + cbxMaTP.Text.Trim() + "', '" + dtpNNC.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                MessageBox.Show("Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn hủy?", "Hủy", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Hide();
            }
        }

        public void Show_cbxMaTP()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string sql = "Select MaNV from NhanVien";
                SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                daPhong.Fill(dt);

                cbxMaTP.DataSource = dt;
                cbxMaTP.ValueMember = "MaNV";
                cbxMaTP.DisplayMember = "MaNV";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbxMaTP_Click(object sender, EventArgs e)
        {
            Show_cbxMaTP();
        }
    }
}
