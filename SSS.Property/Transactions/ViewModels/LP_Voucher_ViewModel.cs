using SSS.Property.Setups;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions.ViewModels
{
  public  class LP_Voucher_ViewModel
    {
        public int idx { get; set; }
        public int voucher_type { get; set; }
        public string voucher_no { get; set; }
        public decimal voucher_amount { get; set; }
        public int payment_type { get; set; }
        public int vendor_id { get; set; }
        public int customer_id { get; set; }
        public string account_cheque_no { get; set; }
        public int bank_id { get; set; }
        [Required(ErrorMessage ="Date is Required")]
        [DataType(DataType.Date)]
        public DateTime date_created { get; set; }
        public int u_id { get; set; }
        public int status { get; set; }
        public bool voucher_proccessed { get; set; }

        public string description { get; set; }

        public string InvoiceNo { get; set; }
        public List<LP_P_Invoice_Property> PInvoiceLST { get; set; }
        [DataType(DataType.Date)]
        public DateTime From_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime To_Date { get; set; }

        public DataTable DetailData { get; set; }
        public List<LP_Voucher_Details> VoucherDetails { get; set; }

        //public List<LP_Transaction_Type_Property> vouchertypelist { get; set; }
        public List<thirdTier_Property> vouchertypelist { get; set; }
        public List<Company_Bank_Property> banklist { get; set; }

        public List<Vendors_Property> vendorlist { get; set; }
        public List<Customers_Property> customerlist { get; set; }
        public string BalanceAmount { get; set; }
        public string PaidAmount { get; set; }
        public decimal Amount { get; set; }
    }
}
