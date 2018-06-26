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
        int sectorid, stockid;
        private List<string> Values = new List<string>();
        private List<int> DID = new List<int>();
        private List<int> DValue = new List<int>();
        private List<string> DDATE = new List<string>();
        private int ID,ID1,NUMBER,IDD;
        private string Date="", NAME="", PWORD="",SECNAME="",STOCKNAME="";
        private int user,crid;
        private int CURRENT=0,STOKCVAL=0, STOCKS=0, SPPROFIT=0, SPLOST=0, SPTOCK=0, PSTROKPRICE=0, SALESTOCKPRICE=0, SALESSTOCKVAL=0, PTOT=0, STOT=0, BALANCE=0;        
        Timer t;
        decimal LOST, BALACE, PROFIT,PPRICE;
        int PSTOCK;
        #endregion
        public csDBOperator()
        {
            Values = csProperties.Value;
            ID = csProperties.ID;
            ID1 = csProperties.ID1;
            stockid = csProperties.Stockid;
            sectorid = csProperties.Sectorid;
            Date = csProperties.Date;
            NAME = csProperties.Name;
            PWORD = csProperties.Pword;
            IDD = csProperties.IDD;
            NUMBER = csProperties.Number;
            BALACE = csProperties.Balance;
            PPRICE = csProperties.Price;
            SECNAME = csProperties.SECNAME;
            STOKCVAL = csProperties.STOKCVAL;
            STOCKS = csProperties.STOCKS;
            CURRENT = csProperties.CURRENT;
            STOCKNAME = csProperties.STOCKNAME;
            PROFIT = csProperties.PROFIT;
            LOST = csProperties.LOST;
          
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
                        sqlquery("sp_insertDataStok");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDate", Date);
                        cmd.Parameters.AddWithValue("@GetValue", Values[i]);
                        cmd.Parameters.AddWithValue("@no", 1);
                        cmd.Parameters.AddWithValue("@name", NAME);
                        cmd.Parameters.AddWithValue("@balance", BALACE);
                        cmd.Parameters.AddWithValue("@price", PPRICE);
                        cmd.Parameters.AddWithValue("@id", IDD);
                        cmd.Parameters.AddWithValue("@id2", 0);

                        sqlnonquery();

                   }
                    closeconnection();
                }
                return "save";
            }

            catch (SqlException ex)
            {
                closeconnection();
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
                        cmd.Parameters.AddWithValue("@balance", BALACE);
                        cmd.Parameters.AddWithValue("@price", 0);
                        cmd.Parameters.AddWithValue("@id2", 0);
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
        public string mdDataFEED2()
        {
            try
            {
                using (con = new SqlConnection(cs))
                {

                    open_connection();
                    sqlquery("sp_insertData");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DDate", "");
                    cmd.Parameters.AddWithValue("@GetValue",NUMBER);
                    cmd.Parameters.AddWithValue("@no", 3);
                    cmd.Parameters.AddWithValue("@name", NAME);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@balance", BALACE);
                    cmd.Parameters.AddWithValue("@price", PPRICE);
                    cmd.Parameters.AddWithValue("@id2", ID1);
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
        public string mdDataFEED3()
        {
            try
            {
                using (con = new SqlConnection(cs))
                {

                    open_connection();
                    sqlquery("sp_salespro");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uname",NAME);
                    cmd.Parameters.AddWithValue("@secname",SECNAME);
                    cmd.Parameters.AddWithValue("@stockname",STOCKNAME);
                    cmd.Parameters.AddWithValue("@stockval", STOKCVAL);
                    cmd.Parameters.AddWithValue("@stocks", STOCKS);
                    cmd.Parameters.AddWithValue("@profit", PROFIT);
                    cmd.Parameters.AddWithValue("@lost", LOST);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@id2", ID1);
                    cmd.Parameters.AddWithValue("@pstockval", SPTOCK);
                    cmd.Parameters.AddWithValue("@pstockprice", PSTROKPRICE);
                    cmd.Parameters.AddWithValue("@saleStockproice", SALESSTOCKVAL);
                    cmd.Parameters.AddWithValue("@saleStockval", SALESTOCKPRICE);
                    cmd.Parameters.AddWithValue("@ptot", PTOT);
                    cmd.Parameters.AddWithValue("@stot", STOT);
                    cmd.Parameters.AddWithValue("@balance", BALANCE);
                    cmd.Parameters.AddWithValue("@curent", CURRENT);
                    
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
        public string mdDataFEED4(out int users)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {

                    open_connection();
                    sqlquery("sp_playerstat");
                    SqlParameter output = new SqlParameter("@users", SqlDbType.Int) { Direction = ParameterDirection.Output };


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tbno", IDD);
                    cmd.Parameters.AddWithValue("@date", Date);
                    cmd.Parameters.AddWithValue("@uname", NAME);
                    cmd.Parameters.Add(output);

                    //sqlnonquery();
                    sqlexcescaler();
                    user = Convert.ToInt32(output.Value.ToString());
                    users = user;

                }

                return "save";
            }

            catch (SqlException ex)
            {
                users = user;
                return ex.ToString();
            }
            finally
            {
                closeconnection();
            }
        }
        public string mdDataFEED5(int cid)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {

                    open_connection();
                    sqlquery("sp_updateid");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@currentid", cid);
                    cmd.Parameters.AddWithValue("@tbno", IDD);
                   
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
                    if (IDD == 1)
                    {
                        sqlquery("select * from vw_tbGetData1 order by ID");
                    }
                    else if (IDD == 2)
                    {
                        sqlquery("select * from vw_tbGetData2 order by ID");
                    }
                    else if (IDD == 3)
                    {
                        sqlquery("select * from vw_tbGetData3 order by ID");
                    }
                    else if (IDD == 4)
                    {
                        sqlquery("select * from vw_tbGetData4 order by ID");
                    }
                    else if (IDD == 5)
                    {
                        sqlquery("select * from vw_tbGetData5 order by ID");
                    }
                    else if (IDD == 6)
                    {
                        sqlquery("select * from vw_tbGetData6 order by ID");
                    }
                    else if (IDD == 7)
                    {
                        sqlquery("select * from vw_tbGetData7 order by ID");
                    }
                    else if (IDD == 8)
                    {
                        sqlquery("select * from vw_tbGetData8 order by ID");
                    }
                    else if (IDD == 9)
                    {
                        sqlquery("select * from vw_tbGetData9 order by ID");
                    }
                    else if (IDD == 10)
                    {
                        sqlquery("select * from vw_tbGetData10 order by ID");
                    }
                    else if (IDD == 11)
                    {
                        sqlquery("select * from vw_tbGetData11 order by ID");
                    }
                    else if (IDD == 12)
                    {
                        sqlquery("select * from vw_tbGetData12 order by ID");
                    }

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
        public void mcbgetPlayerStat(out decimal OPPRICE,out decimal OPSTOCK,out decimal OLOST, out decimal OPROFIT, out decimal OBALACE, string PUNAME)
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
                        LOST = dr.GetDecimal(2);
                        BALACE = dr.GetDecimal(5);
                        PROFIT = dr.GetDecimal(1);
                        PPRICE = dr.GetDecimal(4);
                        PSTOCK = dr.GetInt32(3);
                    }
                }
                OPPRICE = PPRICE;
                OPSTOCK = PROFIT;
                OLOST = LOST;
                OBALACE = BALACE;
                OPROFIT = PROFIT;

                ex = "OK";
            }
            catch (SqlException e)
            {
                OPPRICE = PPRICE;
                OPSTOCK = PROFIT;
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
        public int mgetSALE(out int price, out int stock, out  string name1, out string name2)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {
                    open_connection();
                    sqlquery("SP_SALE");
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter output = new SqlParameter("@PRICE", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter output2 = new SqlParameter("@STOCK", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter output3 = new SqlParameter("@NAME1", SqlDbType.VarChar,50) { Direction = ParameterDirection.Output };
                    SqlParameter output4 = new SqlParameter("@NAME2", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    cmd.Parameters.AddWithValue("@UNAME",NAME);
                    cmd.Parameters.AddWithValue("@ID", sectorid);
                    cmd.Parameters.AddWithValue("@ID2", stockid);
                    

                    cmd.Parameters.Add(output);
                    cmd.Parameters.Add(output2);
                    cmd.Parameters.Add(output3);
                    cmd.Parameters.Add(output4);

                    sqlexcescaler();

                    price = Convert.ToInt32(output.Value.ToString());
                    stock = Convert.ToInt32(output2.Value.ToString());
                    name1 = Convert.ToString(output3.Value.ToString());
                    name2 = Convert.ToString(output4.Value.ToString());


                }
                ex = "DONE";
                return count;
            }
            catch (Exception e)
            {
                ex = e.ToString();
                price = 0;
                stock = 0;
                name2 = e.ToString();
                name1 = e.ToString();
                return 0;
            }
            finally
            {
                closeconnection();
            }
        }
        public void mcbgetCurrentID(out int CRID)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {

                    open_connection();
                    sqlquery("select * from vw_tbgetData WHERE tabno ='" + IDD + "'");

                    quryEx2();
                    while (dr.Read())
                    {
                        crid = dr.GetInt32(1);
                       
                    }
                }
                CRID = crid;    
                ex = "OK";
            }
            catch (SqlException e)
            {
                CRID = crid;
                ex = e.ToString();
            }
            finally
            {
                closeconnection();
            }
        }
        public void mcbgetgetVAL(out decimal OPPRICE, out decimal OPSTOCK, out decimal OLOST, out decimal OPROFIT, out decimal OBALACE, string PUNAME)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {

                    open_connection();
                    sqlquery("SELECT * FROM VW_PLYAERSTAT WHERE UNAME='" + PUNAME + "'");

                    quryEx2();
                    while (dr.Read())
                    {
                        LOST = dr.GetDecimal(2);
                        BALACE = dr.GetDecimal(5);
                        PROFIT = dr.GetDecimal(1);
                        PPRICE = dr.GetDecimal(4);
                        PSTOCK = dr.GetInt32(3);
                    }
                }
                OPPRICE = PPRICE;
                OPSTOCK = PROFIT;
                OLOST = LOST;
                OBALACE = BALACE;
                OPROFIT = PROFIT;

                ex = "OK";
            }
            catch (SqlException e)
            {
                OPPRICE = PPRICE;
                OPSTOCK = PROFIT;
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
        public string mdbuyWithAI(int val,int price,int stokcs)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {

                    open_connection();
                    sqlquery("sp_aibuy");
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.AddWithValue("@uname", NAME);
                    cmd.Parameters.AddWithValue("@avabalacnce", 0);
                    cmd.Parameters.AddWithValue("@val", val);
                    cmd.Parameters.AddWithValue("@id1", sectorid);
                    cmd.Parameters.AddWithValue("@id2", stockid);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stocks", stokcs);
                    cmd.Parameters.AddWithValue("@bankbal", 0);
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
        public string mdSaleWithAI(int val, int price, int stokcs)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {

                    open_connection();
                    sqlquery("sp_aisale");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@sale_price", NAME);
                    cmd.Parameters.AddWithValue("@profit", 0);
                    cmd.Parameters.AddWithValue("@lost", val);
                    cmd.Parameters.AddWithValue("@balance", stockid);
                    cmd.Parameters.AddWithValue("@perchasestock", price);
                    cmd.Parameters.AddWithValue("@prprice", stokcs);
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
        public DataTable mViewData(out string ex)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {
                    open_connection();
                    sqlquery("select * from vw_playerstat");
                    ex = "Executed";
                    return quryEx();
                }
            }
            catch (SqlException e)
            {
                ex = e.ToString();
                return quryEx();
            }
            finally
            {
                closeconnection();
            }
        }
        public DataTable mViewSALE(out string ex)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {
                    open_connection();
                    sqlquery("select * from vw_sale where Uname='"+NAME+"'");
                    ex = "Executed";
                    return quryEx();
                }
            }
            catch (SqlException e)
            {
                ex = e.ToString();
                return quryEx();
            }
            finally
            {
                closeconnection();
            }
        }
        public DataTable mViewBUY(out string ex)
        {
            try
            {
                using (con = new SqlConnection(csConnection.cs))
                {
                    open_connection();
                    sqlquery("select * from vw_buy where Uname='"+NAME+"'");
                    ex = "Executed";
                    return quryEx();
                }
            }
            catch (SqlException e)
            {
                ex = e.ToString();
                return quryEx();
            }
            finally
            {
                closeconnection();
            }
        }
        public string mdAi(string active)
        {
            try
            {
               
                    using (con = new SqlConnection(cs))
                    {

                        open_connection();
                        sqlquery("sp_aipl");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@val", active);
                        
                        sqlnonquery();

                    }
                    closeconnection();
               
                return "save";
            }

            catch (SqlException ex)
            {
                closeconnection();
                return ex.ToString();
            }
            finally
            {
                closeconnection();
            }
        }
        string ss;
        public void mcbai(out string CRID)
        {
            try
            {
                
                using (con = new SqlConnection(csConnection.cs))
                {

                    open_connection();
                    sqlquery("select * from vw_aipl");

                    quryEx2();
                    while (dr.Read())
                    {
                        ss = dr.GetString(0);

                    }
                }
                CRID = ss;
                ex = "OK";
            }
            catch (SqlException e)
            {
                CRID = ss;
                ex = e.ToString();
            }
            finally
            {
                closeconnection();
            }
        }


    }
}
