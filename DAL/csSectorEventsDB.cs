using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class csSectorEventsDB : csConnection
    {
        static List<int> DATASET1 = new List<int>();
        static List<int> DATASET2 = new List<int>();
        static List<int> DATASET3 = new List<int>();
        static List<int> DATASET4 = new List<int>();
        int temp,temp1;
        int SectorID;string ex;
        public string DataSEt()
        {
            SectorID = csProperties.Sectorid;
            if (SectorID == 1)
            {
                try
                {
                    using (con = new SqlConnection(csConnection.cs))
                    {

                        open_connection();
                        sqlquery("select * from tbGetData1");

                        quryEx2();
                        while (dr.Read())
                        {
                            DATASET1.Add(dr.GetInt32(1));

                        }
                    }

                    ex = "OK";
                }
                catch (SqlException e)
                {
                    ex = e.ToString();
                }
                finally
                {
                    closeconnection();
                }

                try
                {
                    using (con = new SqlConnection(csConnection.cs))
                    {

                        open_connection();
                        sqlquery("select * from tbGetData2");

                        quryEx2();
                        while (dr.Read())
                        {
                            DATASET2.Add(dr.GetInt32(1));

                        }
                    }

                    ex = "OK1";
                }
                catch (SqlException e)
                {
                    ex = e.ToString();
                }
                finally
                {
                    closeconnection();
                }
                try
                {
                    using (con = new SqlConnection(csConnection.cs))
                    {

                        open_connection();
                        sqlquery("select * from tbGetData3");

                        quryEx2();
                        while (dr.Read())
                        {
                            DATASET3.Add(dr.GetInt32(1));

                        }
                    }

                    ex = "OK2";
                }
                catch (SqlException e)
                {
                    ex = e.ToString();
                }
                finally
                {
                    closeconnection();
                }
               
        }
            return DATASET1.Count.ToString();
        }
        public int FixList(int id)
        {
            int vall=0;
            if (DATASET1.Count - 1 > id)
            {
                vall += DATASET1[id];
            }
            if (DATASET2.Count - 1 > id)
            {
                vall += DATASET2[id];
            }
            if (DATASET3.Count - 1 > id)
            {
                vall += DATASET3[id];
            }
            vall = vall / 3;

            return vall;
        }
        int max, min;
        string s;
        public string boomORbust(int ii)
        {
            DATASET4.Add(ii);
            for (int i = 0; i < DATASET4.Count; i++)
            {
                if (ii > DATASET4[i])
                {
                    max++;
                }
                else
                {
                    min++;
                }
            }
            if (min > max)
            {
                s = "Bust";
            }
            else
            {
                s = "Boom";
            }
            return s;
        }

         
    }
}
