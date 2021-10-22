using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.MODEL
{
    public class Transaction
    {

        public String type,sender;
        public double amount;
        public readonly String id;
        public Transaction(String bankplusacc_id,String Sder, String typ, double amt)
        {
            id = "TXN" + bankplusacc_id+ DateTime.UtcNow.ToString("MMddyyyy");
            type = typ;
            sender = bankplusacc_id.Substring(11,11);
            amount = amt;

        }

    }
}
