using SSS.DAL.Report;
using SSS.Property.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Report
{
   public class LP_Inventory_BLL
    {
        private LP_Inv_Report objLP_Inv_ReportProperty;
        public Inventory_DAL _objLP_Inv_DAL;
        public LP_Inventory_BLL()
        {
            
        }
        public DataTable SelectAll()
        {
            _objLP_Inv_DAL = new Inventory_DAL();
            return _objLP_Inv_DAL.SelectAll();
        }
        public LP_Inventory_BLL(LP_Inv_Report _objLP_Inv_ReportProperty)
        {
            objLP_Inv_ReportProperty = _objLP_Inv_ReportProperty;
        }
        public DataSet GetInventoryReport()
        {
            _objLP_Inv_DAL = new Inventory_DAL(objLP_Inv_ReportProperty);
            return _objLP_Inv_DAL.GetInventoryReport();
        }
    }
}
