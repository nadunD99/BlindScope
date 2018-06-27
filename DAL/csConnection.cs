using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace DAL
{
    public class csConnection
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataAdapter da;
        protected DataTable dt;
        protected SqlDataReader dr;
        //public DataSet ds;

        // protected static string cs = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
        protected static string cs = "Data Source=119.235.7.221,1433;Initial Catalog=dbSE2;Persist Security Info=True;Min Pool Size=10; Max Pool Size=100;User ID=sa;Password=sa@123";


        protected void open_connection()
        {
            con = new SqlConnection(cs);
            con.Open();

        }
        protected void closeconnection()
        {
            con.Close();
        }
        protected void sqlquery(string qury)
        {
            cmd = new SqlCommand(qury, con);
        }
        protected void sqlnonquery()
        {
            cmd.ExecuteNonQuery();
        }
        protected void sqlexcescaler()
        {
            cmd.ExecuteScalar();
        }
        protected DataTable quryEx()
        {
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        protected void quryEx2()
        {
            dr = cmd.ExecuteReader();
        }
    }
}
