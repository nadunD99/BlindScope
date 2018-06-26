using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class csDBOperator : csConnection
    {
        #region Variables
        private List<int> TABLENO = new List<int>();
        int i;
        string ex;
        private List<string> Values = new List<string>();
        private List<int> DID = new List<int>();
        private List<int> DValue = new List<int>();
        private List<string> DDATE = new List<string>();
        private int ID;
        private string Date;
        #endregion
        public csDBOperator()
        {
            Values = csProperties.Value;
            ID = csProperties.ID;
            Date = csProperties.Date;
        }

        public void mcbgetTableAvailable(out List<int> TBNO)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {

                    open_connection();
                    sqlquery("select * from tbPlayer");
                    quryEx2();
                    while (dr.Read())
                    {
                        TABLENO.Add(dr.GetInt32(0));
                    }

                }
                ex = "OK";
                TBNO = TABLENO;
                
            }
            catch (SqlException e)
            {
                ex = e.ToString();
                TBNO = TABLENO;
                
            }
            finally
            {
                closeconnection();
            }
        }
        public string mdDataFEED()
        {
            try
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    using (con = new SqlConnection(cs))
                    {

                        open_connection();
                        sqlquery("sp_insertData");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDate", Date);
                        cmd.Parameters.AddWithValue("@GetValue", Values[i]);
                        cmd.Parameters.AddWithValue("@no", 1);

                        sqlnonquery();

                   }
                }
                return "save";
            }

            catch (SqlException ex)
            {
                return ex.ToString();
            }
            finally
            {
                closeconnection();
            }
        }
        public void mcbgetTableAvailable(out List<int> DPID, out List<string> DPDATE, out List<int> DPVALUES, out string ex)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {

                    open_connection();
                    sqlquery("select * from vw_tblTransactions order by id");

                    quryEx2();
                    while (dr.Read())
                    {
                        DID.Add(dr.GetInt32(0));
                        DValue.Add(dr.GetInt32(1));
                        DDATE.Add(dr.GetString(2));
                    }

                }
               
                DPID = DID;
                DPVALUES = DValue;
                DPDATE = DDATE;
                ex = "OK";
            }
            catch (SqlException e)
            {
                ex = e.ToString();
                DPID = DID;
                DPVALUES = DValue;
                DPDATE = DDATE;
            }
            finally
            {
                closeconnection();
            }
        }
    }
}
