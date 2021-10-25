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
        public readonly String statement;
        public Transaction(String bankplusacc_id,String Sder, String state,String typ, double amt)
        {
            id = "TXN" + bankplusacc_id+ DateTime.UtcNow.ToString("MMddyyyy");
            type = typ;
            statement=state;
            sender = Sder;
            amount = amt;

        }

    }
}
