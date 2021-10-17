using System;
using System.Collections.Generic;

namespace TechieBank.MODEL
{
    public class Account                                           //a class which creates objects accounts                     
    {
        public string name, ph;                              //history stores transaction history
        private int pin;                                    //stores pin
        private double amount;
        public readonly String id;
        public List<Transaction> history = new List<Transaction>();
        public Account(string pname, string pph, int ppin)      //account constructor
        {
            name = pname;
            ph = pph;
            pin = ppin;
            amount = 0.0;
            id=name.Substring(0,3).ToUpper()+DateTime.UtcNow.ToString("MMddyyyy");
            Console.WriteLine(id);
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
