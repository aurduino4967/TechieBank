using System;
using System.Collections.Generic;

namespace TechieBank.MODEL
{
    public class Account                                           //a class which creates objects accounts                     
    {
        public string name, ph;                              //history stores transaction history
        readonly private int pin;                                    //stores pin
        private double amount;
        public readonly String Bank_id;
        public readonly String id;
        public int tid = 0;
        public List<Transaction> history = new List<Transaction>();
        public Account(String B_id, string pname, string pph, int ppin)      //account constructor
        {
            name = pname;
            ph = pph;
            Bank_id = B_id;
            pin = ppin;
            amount = 0.0;
            id = name.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("MMddyyyy")+DateTime.UtcNow.ToString("HHmmss");
        }
        public double SetAmount(double pamount, bool op)               //amount setter  method
        {
            if (op == true)
            {
                amount += pamount;
            }
            else
                amount -= pamount;
            return amount;
        }
        public int GetPin()                                        //pin getter method
        {
            return pin;
        }
        public double GetAmount()
        {
            return amount;

        }
    }
}
