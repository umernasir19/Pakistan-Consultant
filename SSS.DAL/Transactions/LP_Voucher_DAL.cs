using SNDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using System.Data.SqlClient;
using System.Data;

namespace SSS.DAL.Transactions
{
   public class LP_Voucher_DAL : DBInteractionBase
    {
        LP_Voucher_Property objVoucherProperty;

        public LP_Voucher_DAL()
        {

        }

        public LP_Voucher_DAL(LP_Voucher_Property _objvchrproperty)
        {
            objVoucherProperty = _objvchrproperty;
        }
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (objVoucherProperty.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_PurchaseUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_Voucher_Insert]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (objVoucherProperty.idx > 0)
                {
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.poNumber));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@vendorIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.vendorIdx));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.description));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.totalAmount));

                    //    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.creationDate));

                    //    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.createdByUserIdx));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.visible));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.status));


                    //    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.MRNIdx));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, objVoucherProperty.idx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@voucher_type", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVoucherProperty.voucher_type));
                    cmdToExecute.Parameters.Add(new SqlParameter("@voucher_no", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVoucherProperty.voucher_no));
                    cmdToExecute.Parameters.Add(new SqlParameter("@voucher_amount", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objVoucherProperty.voucher_amount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@payment_type", SqlDbType.Int, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objVoucherProperty.payment_type));
                    cmdToExecute.Parameters.Add(new SqlParameter("@vendor_id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVoucherProperty.vendor_id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@account_cheque_no", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objVoucherProperty.account_cheque_no));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bank_id", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objVoucherProperty.bank_id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@date_created", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVoucherProperty.date_created));
                    cmdToExecute.Parameters.Add(new SqlParameter("@u_id", SqlDbType.Int, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVoucherProperty.u_id));

                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Decimal, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVoucherProperty.status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@voucher_proccessed", SqlDbType.Bit, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, false));
                   cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.Text, 400, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objVoucherProperty.description));


                }

                if (_mainConnectionIsCreatedLocal)
                {

                    OpenConnection();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                //_errorCode = cmdToExecute.Parameters["@ErrorCode"].Value;

                if (objVoucherProperty.DetailData != null)
                {
                    foreach (DataRow row in objVoucherProperty.DetailData.Rows)
                        row["voucher_master_id"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                    objVoucherProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objVoucherProperty.DetailData.TableName = "VoucherDetails";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("voucher_master_id", "voucher_master_id");
                    sbc.ColumnMappings.Add("parent_doc_id", "parent_doc_id");
                    sbc.ColumnMappings.Add("amount", "amount");
                    //sbc.ColumnMappings.Add(2, 1);
                    //sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                    //sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                    //sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                    //sbc.ColumnMappings.Add("qty", "qty");
                    //sbc.ColumnMappings.Add("amount", "amount");
                    //sbc.ColumnMappings.Add("qty", "openItem");
                    //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    //sbc.ColumnMappings.Add("Product", "Product_Name");
                    //sbc.ColumnMappings.Add("Status", "Status");

                    //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    //sbc.ColumnMappings.Add("Description", "Description");

                    sbc.DestinationTableName = objVoucherProperty.DetailData.TableName;
                    sbc.WriteToServer(objVoucherProperty.DetailData);

                }
                //if (objVoucherProperty.InvoiceDetails != null)
                //{
                //    foreach (DataRow row in objVoucherProperty.InvoiceDetails.Rows)
                //        row["PIIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                //    objVoucherProperty.InvoiceDetails.AcceptChanges();

                //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                //    objVoucherProperty.InvoiceDetails.TableName = "PI_Details";

                //    sbc.ColumnMappings.Clear();
                //    sbc.ColumnMappings.Add("ItemIdx", "ItemIdx");
                //    sbc.ColumnMappings.Add("Qty", "Qty");
                //    // sbc.ColumnMappings.Add("ItemIdx", "ItemIdx");
                //    sbc.ColumnMappings.Add("UnitPrice", "UnitPrice");
                //    sbc.ColumnMappings.Add("TotalAmount", "TotalAmount");
                //    //sbc.ColumnMappings.Add("Status", "Status");
                //    //sbc.ColumnMappings.Add(2, 1);
                //    //sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                //    //sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                //    //sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                //    //sbc.ColumnMappings.Add("qty", "qty");
                //    //sbc.ColumnMappings.Add("amount", "amount");
                //    //sbc.ColumnMappings.Add("qty", "openItem");
                //    //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                //    //sbc.ColumnMappings.Add("Product", "Product_Name");
                //    //sbc.ColumnMappings.Add("Status", "Status");

                //    //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                //    //sbc.ColumnMappings.Add("Description", "Description");

                //    sbc.DestinationTableName = objVoucherProperty.InvoiceDetails.TableName;
                //    sbc.WriteToServer(objVoucherProperty.InvoiceDetails);

                //}
                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    //// Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
                }
                cmdToExecute.Dispose();
            }
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllVouchers]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Parent_Code", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Parent_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Conversion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Conversion));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Level", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Level));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Narration));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@Product_Type_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Type));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Packing_Unit_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Packing_Unit_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Small_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Weight));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Length));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Height));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Weight));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Length));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Width));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Height));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Weight));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Length));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Height));
                // cmdToExecute.Parameters.Add(new SqlParameter("@PriceApplyOn", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PriceApplyOn));
                // cmdToExecute.Parameters.Add(new SqlParameter("@SKU_Previous_Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SKU_Previous_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST_Free_SKU", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Free_SKU));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST_Schedule_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Schedule_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Purchase_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Purchase_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Days));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Stop_Days));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Qty_Limit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Qty_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Value_Limit", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Value_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Active));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Defined_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_Date));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Defined_By", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_By));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Is_Final_Product", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Final_Product));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.ID));
                //// cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PageNum));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PageSize));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.TotalRowsNum));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                // Execute query.
                adapter.Fill(toReturn);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelctPOByid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                // cmdToExecute.Parameters.Add(new SqlParameter("@poid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                adapter.Fill(toReturn);


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
        //public string GeneratePO()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_GeneratePONumber]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@tablename", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjDepartmentProperty.TableName));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@coulmn", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,"'"+ ObjDepartmentProperty.ColumnName+"'"));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.createdByUserIdx));
        //       // cmdToExecute.Parameters.Add(new SqlParameter("@PoNumber", SqlDbType.NVarChar, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.poNumber));
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Open connection.
        //            _mainConnection.Open();
        //        }
        //        else
        //        {
        //            if (_mainConnectionProvider.IsTransactionPending)
        //            {
        //                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //            }
        //        }
        //        // Execute query.
        //        //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        //if (_errorCode != (int)LLBLError.AllOk)
        //        //{
        //        //    // Throw error.
        //        //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
        //        //}

        //        //_rowsAffected = Convert.ToInt32(cmdToExecute.ExecuteScalar());
        //        return cmdToExecute.Parameters["@PoNumber"].Value.ToString(); //_rowsAffected;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("PRODUCT_SETUP::SelectAll::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }

        //}

        public DataTable GenerateVoucherNo(LP_GenerateTransNumber_Property objTranNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GenerateTransNo]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Po");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tablename", SqlDbType.VarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@identityfieldname", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.Identityfieldname));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.userid));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                adapter.Fill(toReturn);


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
    }
}
