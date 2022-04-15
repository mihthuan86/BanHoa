using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa
{

    public partial class Site1 : System.Web.UI.MasterPage
    {
        ClassKN kn = new ClassKN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                string sql = "select * from DanhMucHoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, kn.GetConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string madm = ((LinkButton)sender).CommandArgument; //Lấy mã của MaDM bảng DanhMucHoa
            Context.Items["MaDM"] = madm;
            Server.Transfer("SanPham.aspx");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string ten = this.Login1.UserName;
            string mk = this.Login1.Password;
            string sql = "select * from KHACHHANG where TenDN='" + ten + "' and Matkhau='" + mk + "'";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, kn.GetConnection());
                da.Fill(dt);
            }
            catch (SqlException er)
            {
                Response.Write("<b>Error</b>" + er.Message + "</p>");
            }
            if (dt.Rows.Count != 0)
            {
                Response.Cookies["TenDN"].Value = ten;
                Server.Transfer("SanPham.aspx");
            }
            else this.Login1.FailureText = "Tên hoặc mật khẩu không đúng !!!";
        }
    }
}