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
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from NhanVien";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            //UCDSNV ucDS = new UCDSNV();
            //ucDS.Dock = DockStyle.Fill;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(ucDS);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["HoNV"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["TenNV"].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells["SDT"].Value.ToString();
            //textBox6.Text = dataGridView1.SelectedRows[0].Cells["Mã nhân viên"].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells["MaDC"].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells["MaPB"].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells["Luong"].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells["MaCB"].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells["NgayThue"].Value.ToString();
        }
    }
}
