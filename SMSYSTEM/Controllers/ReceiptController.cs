using Newtonsoft.Json;
using SSS.BLL.Setups.Accounts;
using SSS.BLL.Transactions;
using SSS.Property.Setups;
using SSS.Property.Setups.Accounts;
using SSS.Property.Transactions;
using SSS.Property.Transactions.ViewModels;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class ReceiptController : BaseController
    {
        // GET: Receipt
        LP_Voucher_ViewModel objvoucherVM;
        LP_Voucher_BLL objVoucherBll;
        LP_Voucher_Property objvouchermaster;
        public ActionResult Receipts()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }



        #region Add Voucher
        public ActionResult AddReceipt(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                objvoucherVM = new LP_Voucher_ViewModel();
                if (objvoucherVM.idx > 0)
                {

                }
                else
                {
                    thirdTier_BLL subheadBLL = new thirdTier_BLL();
                    var allSubhead = subheadBLL.ViewAll();
                    objvoucherVM.vouchertypelist = Helper.ConvertDataTable<thirdTier_Property>(subheadBLL.ViewAll());
                    objvoucherVM.date_created = DateTime.Now;
                    //objvoucherVM.vouchertypelist = Helper.ConvertDataTable<LP_Transaction_Type_Property>(GetAllTransactionType());
                    objvoucherVM.voucher_amount = 0.00m;
                    objvoucherVM.description = "";
                    objvoucherVM.banklist = Helper.ConvertDataTable<Company_Bank_Property>(GetAllCompanyBanks());
                    objvoucherVM.customerlist = Helper.ConvertDataTable<Customers_Property>(GetAllCustomers());

                    LP_GenerateTransNumber_Property objtransnumber = new LP_GenerateTransNumber_Property();
                    objtransnumber.TableName = "Voucher";
                    objtransnumber.Identityfieldname = "idx";
                    objtransnumber.userid = Session["UID"].ToString();
                    objVoucherBll = new LP_Voucher_BLL();
                    objvoucherVM.voucher_no = objVoucherBll.GenerateTransNo(objtransnumber);

                }

                return View("_AddReceipt", objvoucherVM);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public JsonResult AddUpdate(LP_Voucher_ViewModel objVoucher)
        {
            try
            {
                bool flag = false;
                objvouchermaster = new LP_Voucher_Property();
                objvouchermaster.idx = objVoucher.idx;
                objvouchermaster.voucher_no = objVoucher.voucher_no;
                objvouchermaster.customer_id = objVoucher.customer_id;
                objvouchermaster.voucher_type = 2;// objVoucher.voucher_type;
                objvouchermaster.date_created = objVoucher.date_created;
                if (objVoucher.description != null)
                {
                    objvouchermaster.description = objVoucher.description;
                }
                else
                {
                    objvouchermaster.description = "";
                }
                // objMRNProperty.description = objMRN.description.Length>0? objMRN.description : "";

                //  objMRNProperty.paidDate = ;// objMRN.paidDate;

                objvouchermaster.DetailData = Helper.ToDataTable<LP_Voucher_Details>(objVoucher.VoucherDetails);
                if (objVoucher.idx > 0)
                {
                    ////objMRNProperty.creationDate = DateTime.Now;
                    ////objMRNProperty.visible = 1;
                    ////// objMRNProperty.status = "0";
                    ////objMRNProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    //objvouchermaster.creationDate = DateTime.Now;
                    //objvouchermaster.lastModificationDate = DateTime.Now;
                    //objvouchermaster.lastModifiedByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    ////  objMRNVM_Property.createdByUserIdx = DateTime.Now; ;
                    //objvouchermaster.TableName = "MRNDetails";
                    //objMRNBll = new LP_MRN_BLL(objvouchermaster);
                    //flag = objMRNBll.Insert();
                    //update
                }
                else
                {
                    //add

                    objvouchermaster.status = 0;
                    objvouchermaster.account_cheque_no = objVoucher.account_cheque_no;
                    objvouchermaster.bank_id = objVoucher.bank_id;
                    objvouchermaster.payment_type = objVoucher.payment_type;
                    objvouchermaster.voucher_amount = objVoucher.voucher_amount;

                    objvouchermaster.u_id = Convert.ToInt16(Session["UID"].ToString());

                    objvouchermaster.TableName = "VoucherDetails";
                    objVoucherBll = new LP_Voucher_BLL(objvouchermaster);
                    flag = objVoucherBll.Insert();

                }
                return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SearchSaleInvoice(LP_Voucher_ViewModel objsearchPI)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    //DataTable Data = GetAllPIByDate(objsearchPI);
                    var Data = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSIByDate(objsearchPI));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);

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

        [HttpGet]
        public JsonResult SearchInvoiceForCustomers(int Id)
        {
            try
            {
                LP_SalesOrder_BLL objbll = new LP_SalesOrder_BLL();
                //DataTable tblFiltered;
                if (Id >0)
                {

                    var selectAllInvoices = objbll.SelectAll();
                    var serializeData = JsonConvert.SerializeObject(selectAllInvoices);
                    var allData = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(selectAllInvoices);

                    if (selectAllInvoices.Rows.Count > 0)

                    {
                        var Data = selectAllInvoices.Select().Where(x => x.Field<int>("customerIdx") == Id).Select(c => new { Value = c["idx"], Text = c["soNumber"] }).ToList();

                        //var result = JsonConvert.SerializeObject(Data,
                        //new JsonSerializerSettings
                        //{
                        //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        //});

                        //tblFiltered = selectAllInvoices.AsEnumerable()
                        //        .Where(r => r.Field<int>("VendorID") == Id)
                        //        .CopyToDataTable();
                        //var Data = Helper.ConvertDataTable<LP_P_Invoice_Property>(tblFiltered);
                        return Json(new { data = Data, invData = serializeData, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //var Data = Helper.ConvertDataTable<LP_P_Invoice_Property>(tblFiltered);//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                        return Json(new { data = "", success = false, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }


                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
    }
}