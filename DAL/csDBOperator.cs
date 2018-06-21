using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class csDBOperator : csConnection
    {
        #region Variables
        private List<int> TABLENO = new List<int>();
        int i,count;
        string ex;
        private List<string> Values = new List<string>();
        private List<int> DID = new List<int>();
        private List<int> DValue = new List<int>();
        private List<string> DDATE = new List<string>();
        private int ID;
        private string Date, NAME, PWORD;
        Timer t;
        decimal LOST, BALACE, PROFIT;
        #endregion
        public csDBOperator()
        {
            Values = csProperties.Value;
            ID = csProperties.ID;
            Date = csProperties.Date;
            NAME = csProperties.Name;
            PWORD = csProperties.Pword;
          
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
                        cmd.Parameters.AddWithValue("@name", NAME);
                        cmd.Parameters.AddWithValue("@id", 0);

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
        public string mdDataFEED1()
        {
            try
            {
               using (con = new SqlConnection(cs))
                    {

                        open_connection();
                        sqlquery("sp_insertData");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDate", Date);
                        cmd.Parameters.AddWithValue("@GetValue", 0);
                        cmd.Parameters.AddWithValue("@no",ID );
                        cmd.Parameters.AddWithValue("@name", NAME);
                        cmd.Parameters.AddWithValue("@id", 0);

                        sqlnonquery();

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
                        DID.Add(dr.GetInt32(2));
                        DValue.Add(dr.GetInt32(1));
                        DDATE.Add(dr.GetString(0));
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
        public int mgetLogin(out string ex, out string name2)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {
                    open_connection();
                    sqlquery("SP_LOGIN");
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter output = new SqlParameter("@COUNT", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter output2 = new SqlParameter("@NAME", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    cmd.Parameters.AddWithValue("@UNAME", NAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", PWORD);
                    cmd.Parameters.Add(output);
                    cmd.Parameters.Add(output2);

                    sqlexcescaler();

                    name2 = Convert.ToString(output2.Value.ToString());
                    count = Convert.ToInt32(output.Value.ToString());


                }
                ex = "DONE";
                return count;
            }
            catch (Exception e)
            {
                ex = e.ToString();
                name2 = e.ToString();
                return 0;
            }
            finally
            {
                closeconnection();
            }
        }
        public void mcbgetPlayerStat(out decimal OLOST, out decimal OPROFIT, out decimal OBALACE, string PUNAME)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {

                    open_connection();
                    sqlquery("SELECT * FROM VW_PLYAERSTAT WHERE UNAME='"+PUNAME+"'");

                    quryEx2();
                    while (dr.Read())
                    {
                        LOST = dr.GetDecimal(1);
                        BALACE = dr.GetDecimal(2);
                        PROFIT = dr.GetDecimal(3);
                    }
                }
                OLOST = LOST;
                OBALACE = BALACE;
                OPROFIT = PROFIT;
                ex = "OK";
            }
            catch (SqlException e)
            {
                OLOST = LOST;
                OBALACE = BALACE;
                OPROFIT = PROFIT;
                ex = e.ToString();
            }
            finally
            {
                closeconnection();
            }
        }
    }
}
