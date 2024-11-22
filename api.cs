using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using Oracle.DataAccess;
using System.Threading;
using System.IO;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using api.Models;
//using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Drawing.Printing;
using System.Drawing;
using Oracle.DataAccess.Client;




namespace api.Controllers
{
    public class ederapiController : Controller
    {
        #region "connection"
        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString);

        #endregion
        // GET: ederapi
        public ActionResult Index()
        {
            return View();
        }

        public List<edercls> Get()
        {
            List<edercls> Request = new List<edercls>();
            using (OracleCommand cmd = new OracleCommand())
            {

                cmd.CommandText = string.Format("select * from eder_corrective_v");
                cmd.Connection.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        Request.Add(new edercls
                        {
                            ID = Convert.ToInt32(sdr["ID"].ToString()),
                            Part_num = sdr["part_num"].ToString(),
                            Reject_Date = sdr["reject_date"].ToString(),
                            Part_Name = sdr["part_name"].ToString(),
                            Defect = sdr["defect"].ToString(),
                            Qty = Convert.ToInt32(sdr["qty"].ToString()),
                            FINDING_AREA = sdr["finding_area"].ToString(),
                            CUSTOMER = sdr["customer"].ToString(),
                            Model = sdr["model"].ToString(),
                            Cause = sdr["cause"].ToString(),
                            serial_num = sdr["serial_num"].ToString(),
                            Happen_Cause = sdr["Happen_Cause"].ToString(),
                            Escape_Cause = sdr["Happen_Cause"].ToString(),
                            Corrective_Action = sdr["Corrective_Action"].ToString(),
                            Preventive_Action = sdr["Preventive_Action"].ToString(),
                            ANDON = sdr["ANDON"].ToString(),
                            CAR_Status = sdr["CAR_Status"].ToString(),

                        });



                    }




                }

                cmd.Connection.Close();
            }

            return Request;
        }

        List<edercls> products = new List<edercls>()
            {
                    new edercls {ID=1,CUSTOMER="Samsung TV" ,CATEGORY="3000.000,00"},
                    new edercls {ID=2,CUSTOMER="Nike Shoes" ,CATEGORY="3000.000,00"}
            };


        public JsonResult ProductsData()
        {
            List<edercls> Request1 = new List<edercls>();
            string constr = ConfigurationManager.ConnectionStrings["elderapi"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))

            using (OracleCommand cmd = new OracleCommand())
            {

                // cmd.CommandText = string.Format("select * from eder_support_v");
                cmd.CommandText = string.Format("select * from eder_corrective_v");
                cmd.Connection = con;
                cmd.Connection.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        Request1.Add(new edercls
                        {
                            ID = Convert.ToInt32(sdr["ID"].ToString()),
                            Part_num = sdr["part_num"].ToString(),
                            Reject_Date = sdr["reject_date"].ToString(),
                            Part_Name = sdr["part_name"].ToString(),
                            Defect = sdr["defect"].ToString(),
                            Qty = Convert.ToInt32(sdr["qty"].ToString()),
                            FINDING_AREA = sdr["finding_area"].ToString(),
                            CUSTOMER = sdr["customer"].ToString(),
                            Model = sdr["model"].ToString(),
                            Cause = sdr["cause"].ToString(),
                            serial_num = sdr["serial_num"].ToString(),
                            Division = sdr["Division"].ToString(),
                            Happen_Cause = sdr["Happen_Cause"].ToString(),
                            Escape_Cause = sdr["Escape_Cause"].ToString(),
                            Corrective_Action = sdr["Corrective_Action"].ToString(),
                            Preventive_Action = sdr["Preventive_Action"].ToString(),
                            ANDON = sdr["ANDON"].ToString(),
                            CAR_Status = sdr["CAR_Status"].ToString(),

                        });



                    }




                }

                cmd.Connection.Close();
            }


            return Json(Request1, JsonRequestBehavior.AllowGet);
        }






        public JsonResult ProductsData_oneRow()
        {
            List<edercls> Request1 = new List<edercls>();
            string constr = ConfigurationManager.ConnectionStrings["elderapi"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))

            using (OracleCommand cmd = new OracleCommand())
            {

                // cmd.CommandText = string.Format("select  * from eder_support_v WHERE ROWNUM = 1");
                cmd.CommandText = string.Format("select * from eder_corrective_v WHERE ROWNUM = 1");
                cmd.Connection = con;
                cmd.Connection.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        Request1.Add(new edercls
                        {
                            ID = Convert.ToInt32(sdr["ID"].ToString()),
                            Part_num = sdr["part_num"].ToString(),
                            Reject_Date = sdr["reject_date"].ToString(),
                            Part_Name = sdr["part_name"].ToString(),
                            Defect = sdr["defect"].ToString(),
                            Qty = Convert.ToInt32(sdr["qty"].ToString()),
                            FINDING_AREA = sdr["finding_area"].ToString(),
                            CUSTOMER = sdr["customer"].ToString(),
                            Model = sdr["model"].ToString(),
                            Cause = sdr["cause"].ToString(),
                            serial_num = sdr["serial_num"].ToString(),
                            Division = sdr["Division"].ToString(),
                            Happen_Cause = sdr["Happen_Cause"].ToString(),
                            Escape_Cause = sdr["Happen_Cause"].ToString(),
                            Corrective_Action = sdr["Corrective_Action"].ToString(),
                            Preventive_Action = sdr["Preventive_Action"].ToString(),
                            ANDON = sdr["ANDON"].ToString(),
                            CAR_Status = sdr["CAR_Status"].ToString(),

                        });



                    }




                }

                cmd.Connection.Close();
            }


            return Json(Request1, JsonRequestBehavior.AllowGet);
        }



        public JsonResult ProductsData_bypcba()
        {
            List<edercls> Request1 = new List<edercls>();
            // string strSQL = "select * from eder_support_PCBA_v where  ROWNUM = 1 and STATUS='Open'";
            string strSQL = "select * from eder_corrective_PCBA_v where  ROWNUM = 1 and ANDON='Open'";
            OracleDataAdapter ad = new OracleDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "get");
            int row = ds.Tables["get"].Rows.Count;
            if (row > 0)
            {
                using (OracleCommand cmd = new OracleCommand())
                {

                    cmd.CommandText = string.Format(strSQL);
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using (OracleDataReader sdr = cmd.ExecuteReader())
                    {

                        while (sdr.Read())
                        {
                            Request1.Add(new edercls
                            {
                                ID = Convert.ToInt32(sdr["ID"].ToString()),
                                Part_num = sdr["part_num"].ToString(),
                                Reject_Date = sdr["reject_date"].ToString(),
                                Part_Name = sdr["part_name"].ToString(),
                                Defect = sdr["defect"].ToString(),
                                Qty = Convert.ToInt32(sdr["qty"].ToString()),
                                FINDING_AREA = sdr["finding_area"].ToString(),
                                CUSTOMER = sdr["customer"].ToString(),
                                Model = sdr["model"].ToString(),
                                Cause = sdr["cause"].ToString(),
                                serial_num = sdr["serial_num"].ToString(),

                                Division = sdr["Division"].ToString(),
                                Happen_Cause = sdr["Happen_Cause"].ToString(),
                                Escape_Cause = sdr["Escape_Cause"].ToString(),
                                Corrective_Action = sdr["Corrective_Action"].ToString(),
                                Preventive_Action = sdr["Preventive_Action"].ToString(),
                                ANDON = sdr["ANDON"].ToString(),
                                CAR_Status = sdr["CAR_Status"].ToString(),

                            });



                        }




                    }

                    cmd.Connection.Close();
                }

                return Json(Request1, JsonRequestBehavior.AllowGet);
            }

            else
            {
                string strSQL1 = "select * from eder_corrective_PCBA_v where ROWNUM = 1 and ANDON='Onprocess'";
                OracleDataAdapter ad1 = new OracleDataAdapter(strSQL1, conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "get1");
                int row1 = ds1.Tables["get1"].Rows.Count;
                if (row1 > 0)
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {

                        cmd.CommandText = string.Format(strSQL1);
                        cmd.Connection = conn;
                        cmd.Connection.Open();
                        using (OracleDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                Request1.Add(new edercls
                                {
                                    ID = Convert.ToInt32(sdr["ID"].ToString()),
                                    Part_num = sdr["part_num"].ToString(),
                                    Reject_Date = sdr["reject_date"].ToString(),
                                    Part_Name = sdr["part_name"].ToString(),
                                    Defect = sdr["defect"].ToString(),
                                    Qty = Convert.ToInt32(sdr["qty"].ToString()),
                                    FINDING_AREA = sdr["finding_area"].ToString(),
                                    CUSTOMER = sdr["customer"].ToString(),
                                    Model = sdr["model"].ToString(),
                                    Cause = sdr["cause"].ToString(),
                                    serial_num = sdr["serial_num"].ToString(),

                                    Division = sdr["Division"].ToString(),
                                    Happen_Cause = sdr["Happen_Cause"].ToString(),
                                    Escape_Cause = sdr["Happen_Cause"].ToString(),
                                    Corrective_Action = sdr["Corrective_Action"].ToString(),
                                    Preventive_Action = sdr["Preventive_Action"].ToString(),
                                    ANDON = sdr["ANDON"].ToString(),
                                    CAR_Status = sdr["CAR_Status"].ToString(),

                                });



                            }




                        }

                        cmd.Connection.Close();


                    }


                    return Json(Request1, JsonRequestBehavior.AllowGet);
                }



                string strSQL2 = "select * from eder_corrective_PCBA_v where ROWNUM = 1 and ANDON='Close'";
                OracleDataAdapter ad2 = new OracleDataAdapter(strSQL2, conn);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2, "get2");
                int row2 = ds2.Tables["get2"].Rows.Count;
                if (row2 > 0)
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {

                        cmd.CommandText = string.Format(strSQL2);
                        cmd.Connection = conn;
                        cmd.Connection.Open();
                        using (OracleDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                Request1.Add(new edercls
                                {
                                    ID = Convert.ToInt32(sdr["ID"].ToString()),
                                    Part_num = sdr["part_num"].ToString(),
                                    Reject_Date = sdr["reject_date"].ToString(),
                                    Part_Name = sdr["part_name"].ToString(),
                                    Defect = sdr["defect"].ToString(),
                                    Qty = Convert.ToInt32(sdr["qty"].ToString()),
                                    FINDING_AREA = sdr["finding_area"].ToString(),
                                    CUSTOMER = sdr["customer"].ToString(),
                                    Model = sdr["model"].ToString(),
                                    Cause = sdr["cause"].ToString(),
                                    serial_num = sdr["serial_num"].ToString(),

                                    Division = sdr["Division"].ToString(),
                                    Happen_Cause = sdr["Happen_Cause"].ToString(),
                                    Escape_Cause = sdr["Escape_Cause"].ToString(),
                                    Corrective_Action = sdr["Corrective_Action"].ToString(),
                                    Preventive_Action = sdr["Preventive_Action"].ToString(),
                                    ANDON = sdr["ANDON"].ToString(),
                                    CAR_Status = sdr["CAR_Status"].ToString(),

                                });



                            }




                        }

                        cmd.Connection.Close();
                    }



                }
            }



            return Json(Request1, JsonRequestBehavior.AllowGet);
        }
    }
}
