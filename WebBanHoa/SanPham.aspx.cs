using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebBanHoa
{
    public partial class SanPham : System.Web.UI.Page
    {
        ClassKN kn = new ClassKN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["MaDM"] == null)
                q = "select * from Hoa";
            else
            {
                string maloai = Context.Items["MaDM"].ToString();
                q = "select * from Hoa where MaDM = '" + maloai + "'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, kn.GetConnection());
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
            string masp = ((LinkButton)sender).CommandArgument;
            Context.Items["MaHoa"] = masp;
            Server.Transfer("ChiTiet.aspx");
        }
    }
}