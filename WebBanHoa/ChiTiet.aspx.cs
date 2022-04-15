using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebBanHoa
{
    public partial class ChiTiet : System.Web.UI.Page
    {
        ClassKN kn = new ClassKN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["MaHoa"] == null)
                q = "select * from Hoa";
            else
            {
                string mahang = Context.Items["MaHoa"].ToString();
                q = "select * from Hoa where MaHoa = '" + mahang + "'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, kn.GetConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList2.DataSource = dt;
                this.DataList2.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button mua = (Button)sender;
            string mahang = mua.CommandArgument.ToString(); // Lay bien Argument ow button
            DataListItem item = (DataListItem)mua.Parent;
            int soluong = 1;
            try
            {
                if (Request.Cookies["TenDN"] == null) return; // Neu khong dang nhap thi khong lam gi
                string ten = Request.Cookies["TenDN"].Value;
                SqlConnection con = kn.GetConnection();
                con.Open();
                string query = "select * from DonHang " + " where TenDN = '" + ten + "' and MaHoa = '" + mahang + "'";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader(); // thuc thi cau lenh sql
                if (reader.Read())
                {
                    reader.Close();
                    command = new SqlCommand("update DonHang set SoLuong = SoLuong + '" + soluong + "' where TenDN = '" + ten + "' and MaHoa = '" + mahang + "'", con);
                    soluong++;
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand("insert into DonHang" + "(TenDN,MaHoa,SoLuong) values ('" + ten + "','" + mahang + "','"+soluong+"')", con);
                }
                command.ExecuteNonQuery();  //Khi gap loi nay thi xoa khoa chinh ben DonHang
                con.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}