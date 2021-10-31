using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;

namespace TechieBank.CLI
{
    class Reader : Application_Menu
    {
      
        public static String  AccountRead()
        {
            Print("enter account id");
            String accid = ReadString();
            return accid;
            
        }
        public static int PinRead()
        {
            int pin;
            Print("create a 4 digit pin");
            try
            {   
                pin = ReadInt();
                if (pin < 1000 || pin > 10000)
                    throw new Exception();
                return pin;
            }
            catch
            {
                Print("Invalid Pin");
                return -245;
            }

        }
        public static double AmountRead()
        {
            double amt;
            try
            {
                Print("Enter the amount");
                amt = ReadDouble();
                return amt;
            }
            catch
            {
                Print("Enter valid amount");
                return 0.0;

            }

        }
        public static String BankRead()
        {
            Print("Enter Bank_id");
            String Bank_id = ReadString();
            return Bank_id;

        }
        
    }
}
