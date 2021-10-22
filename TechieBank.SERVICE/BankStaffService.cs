using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;

namespace TechieBank.SERVICE
{
    public class BankStaffService
    {
        public static Bank current;
        public static void Print(String msg)
        { Console.WriteLine(msg); }

        public static  bool ValidateStaff()
        {
            current = BankService.GetBank();
            if (current != null)
            {
                Print("Enter Bank Staff PassCode");
                String passcode = Console.ReadLine();
                if (current.StaffPassCode == passcode)
                    return true;    

            }
            Print("INVALID BANK ID ");
            Console.ReadKey(true);
            return false;    
        }
        public static void Create()
        {
                string name, ph;
                int pin;
                Print("enter your name");
                name = Console.ReadLine();
                Print("enter your phno:");
                ph  = Console.ReadLine();
                pin = Reader.PinRead();

                if (pin != -245)
                {
                    Account created = new Account(current.id, name, ph, pin);
                    current.acnts.Add(created);
                    Print("account creation successful");
                }
                else
                {
                    Print("Bank account can't be created due to incorrect credentials");
                }
            
    
        }

        public static void Delete()
        {
            Account acc = Reader.AccountRead(current);
            current.acnts.Remove(acc);
            Print("Account Deleted Successfully");
        }
    }
}
