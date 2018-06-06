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
    public partial class ucPhongBan : UserControl
    {
        public ucPhongBan()
        {
            InitializeComponent();
        }

        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MINHHIEU\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
            conn.Open();
            string sql = "select *from PhongBan";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPhongBan.DataSource = dt;
        }

        private void ucPhongBan_Load(object sender, EventArgs e)
        {
            KetNoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemMoiPB pb = new ThemMoiPB();
            pb.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaPB pb = new SuaPB();
            pb.lbMaPB.Text = dgvPhongBan.CurrentRow.Cells[0].Value.ToString();
            pb.txtTenPB.Text = dgvPhongBan.CurrentRow.Cells[1].Value.ToString();
            pb.cbxMaTP.Text = dgvPhongBan.CurrentRow.Cells[2].Value.ToString();
            pb.dtpNNC.Text = dgvPhongBan.CurrentRow.Cells[3].Value.ToString();
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
                string sqlTimKiem = "SELECT *FROM PhongBan where MaPB = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("MaPB", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvPhongBan.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPhongBan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvPhongBan.CurrentRow.Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
