using CrystalDecisions.CrystalReports.Engine;
using SSS.BLL.Transactions;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public JsonResult ReportView(int type,int id)
        {
            try
            {
                if (type == 1)
                {
                    //MRN INVOICE
                    GenerateMRNReport(id);
                }

               
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/pdf", "CustomerList.pdf");
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);

            }
        }

        public bool GenerateMRNReport(int mrnid)
        {
            LP_MRN_Master_Property objmrnproperty = new LP_MRN_Master_Property()
            {
                idx = mrnid
            };
           LP_MRN_BLL objBll = new LP_MRN_BLL(objmrnproperty);
            DataTable dt = objBll.SelectById();

            //List<Customer> allCustomer = new List<Customer>();
            //allCustomer = context.Customers.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "InvoiceReport.rpt"));

            rd.SetDataSource(dt);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path.Combine(Server.MapPath("~/Reports"), "InventoryReport.Pdf"));

            return true;
        }
    }
}