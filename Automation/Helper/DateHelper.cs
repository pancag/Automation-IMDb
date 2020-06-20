using Automation.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Automation.Helper
{
    public class DateHelper
    {
       

        public static string GetNowDateTimeAsString()
        {
            return DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
        }
    }
}
