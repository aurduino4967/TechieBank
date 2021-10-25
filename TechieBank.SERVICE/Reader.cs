using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;

namespace TechieBank.SERVICE
{
    public class Reader
    {
        public static void Print(String msg)
        {
            Console.WriteLine(msg);
        }
        public static Account AccountRead(Bank CurBank=null)
        {
            if (CurBank == null)
            {
                CurBank = BankService.GetBank();
            }
            if (CurBank!=null)
            {
                String id;
                Print("enter  account id");
                try
                {
                    id = Convert.ToString(Console.ReadLine());
                    Account k = CurBank.acnts.SingleOrDefault(o => o.id == id);
                    return k;
                }
                catch
                {
                    Print("Invalid Account ID");
                    return null;
                }
            }
            else
                return null;
        }
        public static int PinRead()
        {
            int pin;
            Print("create a 4 digit pin");
            try
            {   
                pin = Convert.ToInt32(Console.ReadLine());
                if (pin < 1000 && pin > 10000)
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
                return -1.0;

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
