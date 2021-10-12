using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.SERVICE
{
    public class Reader
    {
        public static void Print(String msg)
        {
            Console.WriteLine(msg);
        }
        public static int AccountRead()
        {
            int num;
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
                return num;
            }
            catch
            {
                Print("Invalid Account Number");
                return 999;
            }
        }
        public static int PinRead()
        {
            int pin;
            try
            {
                pin = Convert.ToInt32(Console.ReadLine());
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

                amt = Convert.ToDouble(Console.ReadLine());
                return amt;
            }
            catch
            {
                Print("Enter valid amount");
                return -1.0;

            }

        }
    }
}
