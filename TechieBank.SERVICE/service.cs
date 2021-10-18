using System;
using TechieBank.MODEL;

namespace TechieBank.SERVICE
{
    public class Service
    {
        public static Account acc;
        public static int pin;
        public static bool AccountValidate()
        {
            acc = Reader.AccountRead();
            pin = Reader.PinRead();
            if (acc != null && acc.GetPin() == pin)
            {
                return true;
            }
            else
            {
                Print("invalid account credentials account not present");
                Console.ReadKey(true);
                return false; }
        }

        public static void Print(string msg)
        { Console.WriteLine(msg); }


        public static void Create()
        {

            string name, ph;
            int pin;
            Print("enter your name");
            name = Console.ReadLine();
            Print("enter your phno:");
            ph = Console.ReadLine();
            pin = Reader.PinRead();

            if (pin != -245)
            {
                Bank.acnts.Add(new Account(name, ph, pin));
                Print("account creation successful");
            }
            else
            {
                Print("Bank account can't be created");
            }

        }
        public static void Deposit()
        {


            double amt = Reader.AmountRead();
            if (amt > 0)
            {
                Print("\nSuccessfully deposited the money and your current balance is");
                acc.history.Add(new Transaction(acc.id, "Done by : self", "Type : Credit", amt));
                Print(Convert.ToString(acc.SetAmount(amt, true)));
            }
            else
                Print("Invalid amount");



        }



        public static void Withdraw()
        {




            double amt = double.Parse(Console.ReadLine());
            if (acc.GetAmount() >= amt)
            {
                Print("collect your amount");

                acc.SetAmount(amt, false);
                Print("\nSuccessfully withdrawn the money and your current balance is");
                acc.history.Add(new Transaction(acc.id, "Done by : Self", "Type : Debit", amt));
                Print(Convert.ToString(acc.GetAmount()));


            }
            else
            { Print("insufficient balance"); }
        }



        public static void Transfer()
        {


            Print("Enter the Bank account no to transfer");
            Account receiver = Reader.AccountRead();
            if (receiver != null)
            {

                double amt = double.Parse(Console.ReadLine());

                if (acc.GetAmount() >= amt)
                {
                    receiver.SetAmount(amt, true);
                    acc.history.Add(new Transaction(acc.id, "Done by : Self", "type : Debit", amt));
                    receiver.history.Add(new Transaction(acc.id, "Done by : " + acc.name, "type : Credit", amt));

                    Print("\nSuccessfully transferred the money and your current balance is");
                    Print(Convert.ToString(acc.SetAmount(amt, false)));


                }
                else
                { Print("insufficient balance"); }
            }
            else
            { Print("invalid Bank account"); }
        }






        public static void History()
        {


            Console.Clear();

            foreach (Transaction t in acc.history)
            {
                Print("TRANSACTION ID : " + t.id + "\t\t" + t.sender + "\t\t" + t.type + "\t\t" + Convert.ToString(t.amount));
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Print("\n\n\n\n\n\t\t\tyour current balance is   " + acc.GetAmount());
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
