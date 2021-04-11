using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_Inventory_Transfer
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _FromBranchId;
        public int FromBranchId
        {
            get { return _FromBranchId; }
            set { _FromBranchId = value; }
        }

        private int _FromWareHouseId;
        public int FromWareHouseId
        {
            get { return _FromWareHouseId; }
            set { _FromWareHouseId = value; }
        }

        private int _ToBranchId;
        public int ToBranchId
        {
            get { return _ToBranchId; }
            set { _ToBranchId = value; }
        }

        private int _ToWareHouse;
        public int ToWareHouse
        {
            get { return _ToWareHouse; }
            set { _ToWareHouse = value; }
        }

        private DateTime _createionDate;
        public DateTime createionDate
        {
            get { return _createionDate; }
            set { _createionDate = value; }
        }

        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}
