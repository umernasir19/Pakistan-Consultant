﻿using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class WareHouseController : Controller
    {
        // GET: WareHouse
        WareHouse_Property objwarehouse;
        WareHouse_BLL objwarehousebll;
        public ActionResult ViewWareHouse()
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
        public ActionResult AddNewWareHouse(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                objwarehouse = new WareHouse_Property();
                objwarehouse.Idx =Convert.ToInt32(id);
                objwarehousebll = new WareHouse_BLL(objwarehouse);
                DataTable dt = objwarehousebll.SelectOne();
                objwarehouse.WareHouseName = dt.Rows[0]["WareHouseName"].ToString();
                objwarehouse.IsMainWareHouse =Convert.ToBoolean(dt.Rows[0]["IsMainWareHouse"].ToString());
                objwarehouse.BranchIdx= Convert.ToInt32(dt.Rows[0]["BranchIdx"].ToString());
                Branch_BLL objBranch = new Branch_BLL();
                objwarehouse.BranchLists = Helper.ConvertDataTable<Branch_Property>(objBranch.ViewAll());
                
                if (objwarehouse.Idx > 0)
                {
                    return View("_AddNewWareHouse", objwarehouse);
                }
                else
                {
                    return View("_AddNewWareHouse", objwarehouse);
                }
               
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           

        }

        public JsonResult GetAllWarehouse()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
            {

                objwarehousebll = new WareHouse_BLL();
                var Data = JsonConvert.SerializeObject(objwarehousebll.SelectAll());
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


        public JsonResult AddUpdate(WareHouse_Property objwarehousepropert)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
            {
                objwarehouse = new WareHouse_Property();
                objwarehouse = objwarehousepropert;
                objwarehouse.CreationDate = DateTime.Now;
                objwarehouse.CompanyIdx = Convert.ToInt16(Session["COMPANYID"]);
                objwarehouse.createdByUserIdx= Convert.ToInt16(Session["UID"]);
                objwarehouse.IsActive = true;//
                objwarehouse.IsVisible = true;
               objwarehouse.lastModifiedByUserIdx = Convert.ToInt16(Session["UID"]);
                    objwarehouse.LastModificationDate = DateTime.Now;
                    objwarehousebll = new WareHouse_BLL(objwarehouse);
                var flag=objwarehousebll.AddUpdate();
                return Json(new { data = "", success = flag, statuscode = 200, count = "" }, JsonRequestBehavior.AllowGet);

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
    }
}