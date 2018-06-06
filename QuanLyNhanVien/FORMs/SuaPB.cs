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
    public partial class SuaPB : Form
    {
        public SuaPB()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string sua = "update PhongBan set TenPB = N'" + txtTenPB.Text.Trim() + "',MaTP = '" + cbxMaTP.Text.Trim() + "',NNC = '" + dtpNNC.Text.Trim() + "' where  MaPB = '" + lbMaPB.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
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
