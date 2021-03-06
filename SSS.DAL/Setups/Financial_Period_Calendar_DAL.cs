using System;
using System.Collections.Generic;
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

namespace SSS.DAL.Setups
{
    public class Financial_Period_Calendar_DAL : DBInteractionBase
    {
        private Financial_Period_Calendar_Property objFinancialPeriodCalendarProperty;
        private ErrorTracer objErrorTrace;

        public Financial_Period_Calendar_DAL(Financial_Period_Calendar_Property objFinancialPeriodCalendar_Property)
        {
            objFinancialPeriodCalendarProperty = objFinancialPeriodCalendar_Property;
        }

    }
}
