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
        public Transaction(String bankcumacc_id,String Sder, String typ, double amt)
        {
            id = "TXN" + bankcumacc_id+ DateTime.UtcNow.ToString("MMddyyyy");
            type = typ;
            sender = Sder;
            amount = amt;

        }

    }
}
