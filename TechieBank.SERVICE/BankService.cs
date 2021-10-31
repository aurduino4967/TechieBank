using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;
using System.Text.RegularExpressions;
namespace TechieBank.SERVICE

{
    public class BankService
    {
        
        public  List<Bank> Banks = new List<Bank>();
        public String Create(String name, String ifsc)
        {
            if (name.Length < 3 || !(Regex.IsMatch(name, @"^[a-zA-Z]+$")))
                return "invalid bank credentials";
            Bank created = new Bank(name, ifsc);
            Banks.Add(created);
            return created.id;
        }
        public Bank GetBank(String Bank_id)
        {
            return  Banks.SingleOrDefault(o => o.id == Bank_id);
            
        }


    }
}
