using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using SSS.BLL.Report;
using SSS.Property.Report;
using SSS.Property.Setups;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class InventoryController : BaseController
    {
        // GET: Inventory
        LP_Inventory_BLL objLP_Inventory_BLL;
        public ActionResult ViewInventory()
        {
            LP_Inv_Report objinvrprt = new LP_Inv_Report();
            if (Session["LOGGEDIN"] != null)
            {
                objinvrprt.BranchList =Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());
                objinvrprt.ProductList = Helper.ConvertDataTable<Product_Property>(ViewAllProduct());
                return View(objinvrprt);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public JsonResult SelectAllInventory()

        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {

                    objLP_Inventory_BLL = new LP_Inventory_BLL();
                    var Data = JsonConvert.SerializeObject(objLP_Inventory_BLL.SelectAll());
                    return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GenerateDetailReport(LP_Inv_Report objrprtparam)

        {
            try
            {
                objLP_Inventory_BLL = new LP_Inventory_BLL(objrprtparam);
                DataTable dt = objLP_Inventory_BLL.GetInventoryReport().Tables[0];

                //List<Customer> allCustomer = new List<Customer>();
                //allCustomer = context.Customers.ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "InventoryReport.rpt"));

                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path.Combine(Server.MapPath("~/Reports"), "InventoryReport.Pdf"));
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/pdf", "CustomerList.pdf");
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);

            }
        }


        public FileResult Download(string fpath)
        {

            string fullName = Server.MapPath("~" + fpath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullName);
            string fileName = Path.GetFileName(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}