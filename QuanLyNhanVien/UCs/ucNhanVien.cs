using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanVien
{
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
        }

        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
            conn.Open();
            string sql = "select *from NhanVien";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            KetNoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemMoiNV nv = new ThemMoiNV();
            nv.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaNV nv = new SuaNV();
            nv.lbMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            nv.txtHoTen.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            nv.cbxGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            nv.dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            nv.txtSDT.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            nv.txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            nv.cbxCB.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            nv.cbxPB.Text = dgvNhanVien.CurrentRow.Cells[7].Value.ToString();
            nv.txtLuong.Text = dgvNhanVien.CurrentRow.Cells[8].Value.ToString();

            nv.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {

                    SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                    conn.Open();
                    string id = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
                    string xoa;
                    xoa = "delete NhanVien where MaNV = '" + id + "'";
                    SqlCommand comm = new SqlCommand(xoa, conn);
                    SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    daXoa.Fill(dt);
                    dgvNhanVien.DataSource = dt;
                    KetNoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            KetNoi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
                conn.Open();
                string sqlTimKiem = "SELECT *FROM NhanVien where MaNV = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("MaNV", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvNhanVien.CurrentRow.Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
