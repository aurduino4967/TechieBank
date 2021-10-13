using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.MODEL
{
    public class Transaction
    {

        public String type,sender;
        public double amount;
        public Transaction(String Sder, String typ, double amt)
        {
            type = typ;
            sender = Sder;
            amount = amt;

        }

    }
}
