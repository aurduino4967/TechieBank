using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.MODEL
{
    public class Bank
    {
        public String currency,name;
        public readonly String StaffPassCode,id;
        public Dictionary<String, double> RTGS  = new Dictionary<String,double>();   //RTGS mode of transfers and their charges 
        public Dictionary<String, double> IMPS = new Dictionary<String, double>();   //IMPS mode of transfers and their charges

        public List<Account> acnts;
        public  Bank(String name)
        {
            currency = "INR";
            RTGS["SAME"] = 0;
            RTGS["DIFF"] = 2;
            IMPS["SAME"] = 5;
            IMPS["DIFF"] = 6;
            id = name.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("MMddyyyy");
            StaffPassCode='@'+name.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("MMddyyyy");
            acnts = new List<Account>();      //list of accounts
            this.name = name;
            
        } 
    }
}
