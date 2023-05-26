using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmLogin : Form
    {

        #region Variables
        public static string ConnectionString = "Data Source = ANHTUAN\SQLEXPRESS; Initial Catalog = QLNS; User ID = sa; Password = 1";
        #endregion
        public frmLogin()
        {
            InitializeComponent();
            lblError.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                //Kiểm tra xem textbox tài khoản, textbox mật khẩu đã nhập hay chưa
                if (txtTenTKhoan.Text = null && txtTenTKhoan.Text.Trim() != "") { }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin Tên Tài Khoản", "Thông báo");
                    txtTenTKhoan.Focus();
                    return;
                }

                if (txtMatKhau.Text != null && txtMatKhau.Text.Trim() != "") { }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin Mật Khẩu", "Thông Báo");
                    txtMatKhau.Focus();
                    return;
                }

                //Kiểm tra thông tin tài khoản so sánh với thông tin bảng tblTaiKhoan (trong dữ liệu)
                SqlConnection conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string TenTKhoan = txtTenTKhoan.Text.Trim();
                string MatKhau = txtMatKhau.Text.Trim();
                string query = "SELECT * FROM tblTaiKhoan WHERE Ten_TKhoan = '" + TenTKhoan + "' AND Mat_Khau = '" + MatKhau + "'";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    frmMain _frmMain = new frmMain();
                    _frmMain.Show();
                    this.Hide();
                }
                else
                {
                    //Khong tìm thấy
                    lblError.Text = "Thông tin tài khoản hoặc mật khẩu chưa chính xác.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}