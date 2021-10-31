using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;

namespace TechieBank.CLI
{
    public class Reader
    {
        public static void Print(String msg)
        {
            Console.WriteLine(msg);
        }
        public static String  AccountRead()
        {
            Print("enter account id");
            String accid = Convert.ToString(Console.ReadLine());
            return accid;
            
        }
        public static int PinRead()
        {
            int pin;
            Print("create a 4 digit pin");
            try
            {   
                pin = Convert.ToInt32(Console.ReadLine());
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
                amt = Convert.ToDouble(Console.ReadLine());
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
            String Bank_id = Convert.ToString(Console.ReadLine());
            return Bank_id;

        }
        
    }
}
