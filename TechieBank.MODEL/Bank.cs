using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.MODEL
{
    public class Bank
    {
        public String currency,name;
        public readonly String StaffPassCode,id;
        public readonly String IFSC;
        public Dictionary<String, double> RTGS  = new Dictionary<String,double>();   //RTGS mode of transfers and their charges 
        public Dictionary<String, double> IMPS = new Dictionary<String, double>();   //IMPS mode of transfers and their charges

        public List<Account> acnts;
        public  Bank(String name,String ifs)
        {
            currency = "INR";
            RTGS["SAME"] = 0;
            RTGS["DIFF"] = 2;
            IMPS["SAME"] = 5;
            IMPS["DIFF"] = 6;
            IFSC = ifs;
            id = name.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("MMddyyyy")+ DateTime.UtcNow.ToString("HHmmss");
            StaffPassCode='@'+id;
            acnts = new List<Account>();      //list of accounts
            this.name = name;
            
        } 
    }
}
