using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using FluentValidation;
using SNDDAL;
using SSS.Property.Setups;
using System;

namespace SSS.DAL.Setups
{
    public class Distributor_Setup_DAL : DBInteractionBase
    {
        private Distributor_Setup_Property objDistSetupProperty;
        private ErrorTracer objErrorTrace;

        public Distributor_Setup_DAL(Distributor_Setup_Property objDistSetup_Property)
        {
            objDistSetupProperty = objDistSetup_Property;
        }

        /// <summary>
        /// Purpose: SelectAll method. This method will Select all rows from the table.
        /// </summary>
        /// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        /// 


        //public  DataTable SelectAllPOSSetup(int types)
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    if (types == 1)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_DetailReport]";
        //    }
        //    else if (types == 2)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_SlowMovingReport]";
        //    }
        //    else if (types == 3)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_TopMoivingReport]";
        //    }
        //    else if (types == 4)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_SummaryReport]";
        //    }
        //    else if (types == 5)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_TopSlowMoving_ReportFromBothTables]";//"dbo.[POS_TopSlowMoving_Report]";
        //    }
        //    else if (types == 6)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_TopSlowMoving_RptQTYForBothTables]";//"dbo.[POS_TopSlowMoving_RptQTY]";
        //    }
        //    else if (types == 7)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_TopSlowMoving_Report_RouteGroup]";
        //    }
        //    else if (types == 8)
        //    {
        //        cmdToExecute.CommandText = "dbo.[sp_Rpt_POSInformationDistinctPOS]";
        //    }
        //    if (types == 11)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_DetailReport_WithLastBillAmount]";
        //    }
        //    if (types == 12)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_DetailReport_WithPJP]";
        //    }
        //    if (types == 101)
        //    {
        //        cmdToExecute.CommandText = "dbo.[POS_DetailReport_ReplicaFreezerandChiller]";
        //    }
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    DataTable toReturn = new DataTable();
        //   // DataTable toReturn;
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {

        //        if (types == 1)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
        //        }


        //        if (types == 2)
        //        {

        //            cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //            //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
        //        }
        //       
        //       
        //        else if (types == 2)
        //        {

        //            cmdToExecute.Parameters.Add(new SqlParameter("@PersRepXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@AmountFrom", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amountfrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@AmountTo", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amounttopos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
        //        }
        //        else if (types == 3)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@PersRepXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int , 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord ));
        //        }
                     //if (types == 4)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //            //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
        //        }
        //        else if (types == 5)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@ProXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@TypeRecd", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID   ));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@tax", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Tax  ));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Distubtr_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ID ));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@AmountFrom", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amountfrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@AmountTo", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amounttopos));
        //            //cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //        }
        //        else if (types == 6)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@ProXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@TypeRecd", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@tax", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Tax));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Distubtr_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@fromQty", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.FromQuantity ));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@ToQty", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ToQuantity ));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));


        //        }
        //        else if (types == 7)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@ProXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@TypeRecd", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@tax", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Tax));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Distubtr_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@AmountFrom", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amountfrompos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@AmountTo", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amounttopos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //        }
        //        else if (types == 8)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));

        //        }
         //if (types == 11)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //            //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
        //        }
        //        if (types == 12)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //            //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
        //        }
        //        if (types == 101)
        //        {
        //            cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
        //        }
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

        //        cmdToExecute.CommandTimeout = 0;

        //        // Execute query.
        //        adapter.Fill(toReturn);
        //        //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        //if (_errorCode != (int)LLBLError.AllOk)
        //        //{
        //        //    // Throw error.
        //        //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
        //        //}



        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //        adapter.Dispose();
        //    }
        //}

        public DataTable SelectAllPOSSetup(int types)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (types == 1)
            {
                cmdToExecute.CommandText = "dbo.[POS_DetailReport]";
            }
            else if (types == 2)
            {
                cmdToExecute.CommandText = "dbo.[POS_SlowMovingReport]";
            }
            else if (types == 3)
            {
                cmdToExecute.CommandText = "dbo.[POS_TopMoivingReport]";
            }
            else if (types == 4)
            {
                cmdToExecute.CommandText = "dbo.[POS_SummaryReport]";
            }
            else if (types == 5)
            {
                cmdToExecute.CommandText = "dbo.[POS_TopSlowMoving_ReportFromBothTables]";//"dbo.[POS_TopSlowMoving_Report]";
            }
            else if (types == 6)
            {
                cmdToExecute.CommandText = "dbo.[POS_TopSlowMoving_RptQTYForBothTables]";//"dbo.[POS_TopSlowMoving_RptQTY]";
            }
            else if (types == 7)
            {
                cmdToExecute.CommandText = "dbo.[POS_TopSlowMoving_Report_RouteGroup]";
            }
            else if (types == 8)
            {
                cmdToExecute.CommandText = "dbo.[sp_Rpt_POSInformationDistinctPOS]";
            }
            if (types == 11)
            {
                cmdToExecute.CommandText = "dbo.[POS_DetailReport_WithLastBillAmount]";
            }
            if (types == 12)
            {
                cmdToExecute.CommandText = "dbo.[POS_DetailReport_WithPJP]";
            }
            if (types == 101)
            {
                cmdToExecute.CommandText = "dbo.[POS_DetailReport_ReplicaFreezerandChiller]";
            }
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable();
            // DataTable toReturn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
                cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
                cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
                cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));

                if (types == 2)
                {

                    cmdToExecute.Parameters.Add(new SqlParameter("@PersRepXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@AmountFrom", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amountfrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@AmountTo", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amounttopos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                }
                else if (types == 3)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@PersRepXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
                }
                //if (types == 4)
                //{
                //    cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
                //    //cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
                //    //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
                //}


                else if (types == 5)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@TypeRecd", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tax", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Tax));
                    cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Distubtr_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@AmountFrom", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amountfrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@AmountTo", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amounttopos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaleTypeReport", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPosWithSold));
                }
                else if (types == 6)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@TypeRecd", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tax", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Tax));
                    cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Distubtr_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@fromQty", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.FromQuantity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ToQty", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ToQuantity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaleTypeReport", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPosWithSold));

                }
                else if (types == 7)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProXml", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@toprec", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Toprecord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@TypeRecd", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tax", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Tax));
                    cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Distubtr_id", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@AmountFrom", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amountfrompos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@AmountTo", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Amounttopos));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
                }
                else if (types == 8)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));

                }
                //if (types == 11)
                //{
                //    cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
                //    //cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
                //    //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
                //}
                //if (types == 12)
                //{
                //    cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
                //    //cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
                //    //cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
                //}
                if (types == 101)
                {
                    //cmdToExecute.Parameters.Add(new SqlParameter("@DistXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@RouteXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.RouteXML));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@POSXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.POSXML));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@BusnesXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@LocationXML", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.LocationXML));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
                    cmdToExecute.Parameters.Add(new SqlParameter("@POSType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PosTypes));
                }
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

                cmdToExecute.CommandTimeout = 0;

                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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


        public DataTable DamageExpiryReport()
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "dbo.[sp_DamageOrExpiryReport]";//"dbo.[POS_TopSlowMoving_Report]";
            
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable();
            // DataTable toReturn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                cmdToExecute.Parameters.Add(new SqlParameter("@posBusinessType", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                cmdToExecute.Parameters.Add(new SqlParameter("@orderBookerId", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                
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

                cmdToExecute.CommandTimeout = 0;
                adapter.Fill(toReturn);
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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

        public DataTable DamageExpiryReportProductWise()
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "dbo.[sp_DamageOrExpiryReportProductWise]";//"dbo.[POS_TopSlowMoving_Report]";

            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable();
            // DataTable toReturn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (objDistSetupProperty.DistXML)));
                cmdToExecute.Parameters.Add(new SqlParameter("@posBusinessType", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.BusnesXML));
                cmdToExecute.Parameters.Add(new SqlParameter("@orderBookerId", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Datefrompos));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.datetopos));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ProductXml));

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

                cmdToExecute.CommandTimeout = 0;
                adapter.Fill(toReturn);
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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
               
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_MST_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTOR_MST_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Location_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Registration_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Registration_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TotalRowsNum));

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
                cmdToExecute.CommandTimeout = 0;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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

        public DataTable SelectById()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_MST_SETUP_GetById]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTOR_MST_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                
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
                cmdToExecute.CommandTimeout = 0;
                adapter.Fill(toReturn);
               


                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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


        public DataTable SelectAllDistributorWithoutRegion()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTORSelectAllWithoutRegion]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTOR_MST_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Location_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Registration_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Registration_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TotalRowsNum));

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
                cmdToExecute.CommandTimeout = 0;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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
        
        public DataTable DISTRIBUTORName_AllTransacStatusday(string datefrom1, string dateto1)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTORName_TransacStatusday]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTORName_CLOSING_DAY");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Date_From", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, datefrom1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Date_To", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, dateto1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));


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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable DISTRIBUTORName_AllTransacStatusdayForToDays()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTORName_TransacStatusdayForToDays]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTORName_CLOSING_DAY");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {

                //cmdToExecute.Parameters.Add(new SqlParameter("@Date_From", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, datefrom1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Date_To", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, dateto1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));


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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable DISTRIBUTORName_CLOSING_DAY()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTORName_CLOSING_DAY]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTORName_CLOSING_DAY");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@Distid", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Batchid", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Batch_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Priceid", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Price_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@type", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));


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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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

        public DataSet DistImportExportData()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (objDistSetupProperty.TyesPos == 1)
            {
                cmdToExecute.CommandText = "dbo.[Sp_ImportSetupHO_Offline]";
            }
            if (objDistSetupProperty.TyesPos == 2)
            {
                cmdToExecute.CommandText = "dbo.[Sp_ExportDist_Offline]";
            }
            if (objDistSetupProperty.TyesPos == 3)
            {

                cmdToExecute.CommandText = "dbo.[Sp_SetupTableDist_Offline]";
            }
            if (objDistSetupProperty.TyesPos == 4)
            {

                cmdToExecute.CommandText = "dbo.[Sp_ExportSetupDist_Offline]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("SetupTableDist_Offline");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (objDistSetupProperty.TyesPos == 1)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@xml", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.DistXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Servername", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Servername));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Dbname", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Dbname));
                }
                if (objDistSetupProperty.TyesPos == 2)
                {

                    cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.From_Date));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TO_Date));

                }
                if (objDistSetupProperty.TyesPos == 3)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));

                }

                if (objDistSetupProperty.TyesPos == 4)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Tempxml));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tablenames", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Personlxml));
                }

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
                cmdToExecute.CommandTimeout = 0;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Sp_SetupTableHO_Offline::SelectAll::Error occured.", ex);
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

        public DataSet HOImportExportData()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (objDistSetupProperty.TyesPos == 1)
            {
                cmdToExecute.CommandText = "dbo.[Sp_ExportSetupHO_OfflineNew]";//"dbo.[Sp_ExportSetupHO_Offline]";
            }
            else if (objDistSetupProperty.TyesPos == 2)
            {
                cmdToExecute.CommandText = "dbo.[Sp_SetupTableHO_Offline]";
            }
            else if (objDistSetupProperty.TyesPos == 3)
            {
                cmdToExecute.CommandText = "dbo.[Sp_ImportDataDist_Offline]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("SetupTableHO_Offline");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (objDistSetupProperty.TyesPos == 1)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@Step", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TypeRecID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.DistXML));
                }
                if (objDistSetupProperty.TyesPos == 3)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xml", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.DistXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Servername", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Servername));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Dbname", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Dbname));
                    cmdToExecute.Parameters.Add(new SqlParameter("@transactionflag", SqlDbType.Bit, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TransactionFlag));
                    
                }
                if (objDistSetupProperty.TyesPos == 2)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.DateFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.DateTo));
                }

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
                cmdToExecute.CommandTimeout = 0;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Sp_SetupTableHO_Offline::SelectAll::Error occured.", ex);
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
       
        public DataTable Select_Distributor_Setup_Prioity()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Distributor_Setup_Prioity]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Distributor_Setup_Prioity");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distid", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batchid", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Priceid", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Price_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@type", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TyesPos));
               

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
               // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectAll::Error occured.", ex);
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
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_MST_SETUP_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sDistributor_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iLocation_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Location_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDistributor_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOwner_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Owner_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@iRegistration_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Registration_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sTax_Number", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Tax_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPhone1", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Phone1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPhone2", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Phone2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sMobile_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Mobile_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sUAN_Number", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.UAN_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@iFax_Number", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,objDistSetupProperty.Fax_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.URL));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPost_Code", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Post_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sTelegraph_Add", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Telegraph_Add));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRailway_Station", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Railway_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCapital_Invest", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Capital_Invest));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCurrent_Balance", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Current_Balance));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDate_Of_Join", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Date_Of_Join));
                cmdToExecute.Parameters.Add(new SqlParameter("@daWorking_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Working_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDay_Off", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Day_Off));
                cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Active_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@sParent_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Parent_ID));
                
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ErrorCode));

                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Operated_By));
                


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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                objDistSetupProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                objDistSetupProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISTRIBUTOR_MST_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }
        public bool InsertDistByDiscount()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[Discount_DISTRIBUTOR_TYPE_DETAIL _Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                // The formal parameter "@ID" was not declared as an OUTPUT parameter, but the actual parameter passed in requested output.
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.DiscountId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                //  cmdToExecute.Parameters.Add(new SqlParameter("@POS_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Business_Type_Detail_Property.POS_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));


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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Discount_DISTRIBUTOR_TYPE_DETAIL _Insert' reported the ErrorCode: " + _errorCode);
                    // return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Discount_BusinessType::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }
    
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_MST_SETUP_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sDistributor_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iLocation_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Location_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDistributor_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Distributor_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOwner_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Owner_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@iRegistration_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Registration_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sTax_Number", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Tax_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPhone1", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Phone1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPhone2", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Phone2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sMobile_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Mobile_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sUAN_Number", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.UAN_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@iFax_Number", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Fax_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@sURL", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.URL));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPost_Code", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Post_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sTelegraph_Add", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Telegraph_Add));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRailway_Station", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Railway_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCapital_Invest", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Capital_Invest));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCurrent_Balance", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, objDistSetupProperty.Current_Balance));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDate_Of_Join", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Date_Of_Join));
                cmdToExecute.Parameters.Add(new SqlParameter("@daWorking_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Working_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDay_Off", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Day_Off));
                cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Active_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@sParent_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Parent_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ErrorCode));

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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                objDistSetupProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISTRIBUTOR_MST_SETUP_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::Update::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }
        
        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistSetupProperty.Operated_By));

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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //// some error occured. Bubble it to caller and encapsulate Exception object
                //objErrorTrace.Error_Msg = (SqlString)ex.Message;
                //objErrorTrace.Error_Proc = "sp_POS_SETUP_UpdateStatus";
                //objErrorTrace.Insert();
                //HttpContext.Current.Response.Redirect("~/Error.aspx");


                ////Send Email To Application Developer's
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                //mailMessage.To.Add("ammar.ali@armtech.com.pk");
                //mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                //mailMessage.From = new MailAddress("Error@SSS.com");
                //mailMessage.Subject = "Error in sp_CURRENCY_SETUP_Insert";
                //mailMessage.Body = (String)objErrorTrace.Error_Msg;
                //SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                //smtpClient.Send(mailMessage);



                return false;

            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }

        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_MST_SETUP_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISTRIBUTOR_MST_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objDistSetupProperty.ErrorCode));

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
                objDistSetupProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (objDistSetupProperty.ErrorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISTRIBUTOR_MST_SETUP_SelectOne' reported the ErrorCode: " + objDistSetupProperty.ErrorCode);
                }

                if (toReturn.Rows.Count > 0)
                {  // toReturn.Rows[0]["Fax_Number"] == System.DBNull.Value ? SqlInt32.Null : (Int32)
                    //toReturn.Rows[0]["Post_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)
                    //toReturn.Rows[0]["Capital_Invest"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)
                    objDistSetupProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objDistSetupProperty.Distributor_Code = (string)toReturn.Rows[0]["Distributor_Code"];
                    objDistSetupProperty.Company_ID = toReturn.Rows[0]["Company_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_ID"];
                    objDistSetupProperty.Location_Setup_ID = toReturn.Rows[0]["Location_Setup_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Location_Setup_ID"];
                    objDistSetupProperty.Distributor_Name = toReturn.Rows[0]["Distributor_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Distributor_Name"];
                    objDistSetupProperty.Address = toReturn.Rows[0]["Address"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Address"];
                    objDistSetupProperty.Owner_Name = toReturn.Rows[0]["Owner_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Owner_Name"];
                    objDistSetupProperty.Registration_Type_ID = (Int32)toReturn.Rows[0]["Registration_Type_ID"];
                    objDistSetupProperty.Tax_Number = toReturn.Rows[0]["Tax_Number"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Tax_Number"];
                    objDistSetupProperty.Phone1 = toReturn.Rows[0]["Phone1"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Phone1"];
                    objDistSetupProperty.Phone2 = toReturn.Rows[0]["Phone2"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Phone2"];
                    objDistSetupProperty.Mobile_No = toReturn.Rows[0]["Mobile_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Mobile_No"];
                    objDistSetupProperty.UAN_Number = toReturn.Rows[0]["UAN_Number"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["UAN_Number"];
                    objDistSetupProperty.Fax_Number = toReturn.Rows[0]["Fax_Number"] == System.DBNull.Value ? (int?)null : (Int32)toReturn.Rows[0]["Fax_Number"];
                    objDistSetupProperty.Email = toReturn.Rows[0]["Email"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Email"];
                    objDistSetupProperty.URL = toReturn.Rows[0]["URL"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["URL"];
                    objDistSetupProperty.Post_Code = toReturn.Rows[0]["Post_Code"] == System.DBNull.Value ? (int?)null : (Int32)toReturn.Rows[0]["Post_Code"];
                    objDistSetupProperty.Telegraph_Add = toReturn.Rows[0]["Telegraph_Add"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Telegraph_Add"];
                    objDistSetupProperty.Railway_Station = toReturn.Rows[0]["Railway_Station"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Railway_Station"];
                    objDistSetupProperty.Police_Station = toReturn.Rows[0]["Police_Station"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Police_Station"];
                    objDistSetupProperty.Capital_Invest = toReturn.Rows[0]["Capital_Invest"] == System.DBNull.Value ? (decimal?)null : (decimal)toReturn.Rows[0]["Capital_Invest"];
                    objDistSetupProperty.Current_Balance = toReturn.Rows[0]["Current_Balance"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Current_Balance"];
                    objDistSetupProperty.Date_Of_Join = toReturn.Rows[0]["Date_Of_Join"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Date_Of_Join"];
                    objDistSetupProperty.Working_Date = toReturn.Rows[0]["Working_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Working_Date"];
                    objDistSetupProperty.Day_Off = toReturn.Rows[0]["Day_Off"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Day_Off"];
                    objDistSetupProperty.Active_Status = (string)toReturn.Rows[0]["Active_Status"];
                    objDistSetupProperty.Is_Active = toReturn.Rows[0]["Is_Active"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Is_Active"];
                    objDistSetupProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                    objDistSetupProperty.Parent_ID = toReturn.Rows[0]["Parent_ID"] == System.DBNull.Value ? (int?)null : (Int32)toReturn.Rows[0]["Parent_ID"];
                    
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISTRIBUTOR_MST_SETUP::SelectOne::Error occured.", ex);
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
