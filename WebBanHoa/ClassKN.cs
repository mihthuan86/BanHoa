using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebBanHoa
{
    public class ClassKN
    {
        //string ckn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Desktop\WebBanHoa\WebBanHoa\App_Data\DatabaseHoa.mdf;Integrated Security=True";
        //Làm trên trường thì làm chuỗi ckn
        SqlConnection con;
        public SqlConnection GetConnection()
        {
            string path = HttpContext.Current.Server.MapPath("App_Data/DatabaseHoa.mdf");
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + "; Integrated Security=True");    //Cái 2 dòng này là làm ở nhà thôi


            //return con = new SqlConnection(ckn);  //Làm trên trường
        }
        private void OpenKN()
        {
            con = GetConnection();
            con.Open(); // 2 Dòng này cũng làm ở nhà thôi


            //GetConnection().Open(); //Làm trên trường
        }

        private void CloseKN()
        {
            if (GetConnection().State == ConnectionState.Open)
                GetConnection().Close();
        }
        public int Update(string sql)
        {
            int kq = 0;
            try
            {
                OpenKN();
                SqlCommand cmd = new SqlCommand(sql, GetConnection());
                kq = cmd.ExecuteNonQuery();
            }
            catch
            {
                kq = 0;
            }
            finally
            {
                CloseKN();
            }
            return kq;
        }

        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenKN();
                SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            finally { CloseKN(); }
            return dt;
        }

        public int xulydl(string sql)
        {
            int kq = 0;
            try
            {
                OpenKN();
                SqlCommand cmd = new SqlCommand(sql, GetConnection());
                kq = cmd.ExecuteNonQuery();
            }
            catch
            {
                kq = 0;
            }
            finally
            {
                CloseKN();
            }
            return kq;
        }
    }
}