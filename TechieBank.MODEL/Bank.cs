using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.MODEL
{
    public class Bank
    {
        public List<Account> acnts;
        public readonly String id;
        public readonly String name="";
        public Bank(String name)
        {
            id = name.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("MMddyyyy");
            acnts = new List<Account>();      //list of accounts
            this.name = name;
        } 
    }
}
