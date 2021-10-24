using System;
using TechieBank.MODEL;
using System.Linq;

namespace TechieBank.SERVICE
{
    public class AccountService
    {
        public static Account acc;
        public static int pin;
        
        public static bool AccountValidate()
        {
            acc =Reader.AccountRead();
            
            if (acc != null && acc.GetPin() ==  Reader.PinRead())
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
        public static void Deposit()
        {
            double amt = Reader.AmountRead();
            acc.SetAmount(amt, true);
            Print("\nSuccessfully withdrawn the money and your current balance is");
            acc.history.Add(new Transaction(acc.Bank_id + acc.id, "Done by : Self", "Type : Credit", amt));
            Print(Convert.ToString(acc.GetAmount()));

        }

        


        public static void Withdraw()
        {

            
            double amt = Reader.AmountRead();
            if (acc.GetAmount() >= amt)
            {
                Print("collect your amount");

                acc.SetAmount(amt, false);
                Print("\nSuccessfully withdrawn the money and your current balance is");
                acc.history.Add(new Transaction(acc.Bank_id+acc.Bank_id+acc.id, "Done by : Self", "Type : Debit", amt));
                Print(Convert.ToString(acc.GetAmount()));


            }
            else
            { Print("insufficient balance"); }
        }



        public static void Transfer()
        {

            
            Print("DETAILS OF DEBITOR OR RECEIVER");
            Account receiver = Reader.AccountRead();
            if (receiver != null)
            {
                string eqornoteq = acc.Bank_id == receiver.Bank_id ? "SAME" : "DIFF";
                double temp,amt = Reader.AmountRead();

                if (acc.GetAmount() >= amt)
                {
                    Print("enter the mode of Transfer   \n1.RTGS (or) \n2.IMPS\n");
                    Bank k = BankService.Banks.SingleOrDefault(o => o.id == acc.Bank_id);
                    temp = Console.ReadLine() == "RTGS" ?  amt * (k.RTGS[eqornoteq])/100 : amt * (k.IMPS[eqornoteq])/100;
                    receiver.SetAmount(amt-temp, true);
                    acc.history.Add(new Transaction(acc.Bank_id+acc.id, "Done by : Self", "type : Debit", amt));
                    receiver.history.Add(new Transaction(acc.Bank_id + acc.id, "Done by : " + acc.id, "type : Credit", amt));
                    Print("\nSuccessfully transferred the money and your current balance is");
                    Print(Convert.ToString(acc.SetAmount(amt, false)));


                }
                else
                { Print("insufficient balance"); }
            }
            else
            { Print("invalid  account"); }
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
