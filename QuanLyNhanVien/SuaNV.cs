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
    public partial class SuaNV : Form
    {
        public SuaNV()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string sua = "update NhanVien set HoTen = N'" + txtHoTen.Text.Trim() + "',GioiTinh = '" + cbxGioiTinh.Text.Trim() + "',NgaySinh = '" + dtpNgaySinh.Text.Trim() + "',SDT = '" + txtSDT.Text.Trim() + "',DiaChi = N'" + txtDiaChi.Text.Trim() + "',MaCB = '" + cbxCB.Text.Trim() + "',MaPB = '" + cbxPB.Text.Trim() + "',Luong = '" + txtLuong.Text.Trim() + "' where  MaNV = '" +lbMaNV.Text.Trim()+ "'";
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

        public void Show_cbxCB()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string sql = "Select MaCB from CapBac";
                SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                daPhong.Fill(dt);

                cbxCB.DataSource = dt;
                cbxCB.ValueMember = "MaCB";
                cbxCB.DisplayMember = "MaCB";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Show_cbxPB()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string sql = "Select MaPB from PhongBan";
                SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                daPhong.Fill(dt);

                cbxPB.DataSource = dt;
                cbxPB.ValueMember = "MaPB";
                cbxPB.DisplayMember = "MaPB";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbxCB_Click(object sender, EventArgs e)
        {
            Show_cbxCB();
        }

        private void cbxPB_Click(object sender, EventArgs e)
        {
            Show_cbxPB();
        }
    }
}
