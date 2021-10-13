using System;
using TechieBank.MODEL;

namespace TechieBank.SERVICE
{
    public class Service
    {
        public static void Print(string msg)
        {
                    Console.WriteLine(msg);
        }

        public static void Create()
        {

            string name, ph;
            int pin;
            Print("enter your name");
            name = Console.ReadLine();

            Print("enter your phno:");
            ph = Console.ReadLine();
            Print("create a 4 digit pin");
            pin = Reader.PinRead();
            if (pin != -245)
            {
                Bank.i += 1;
                Bank.acnts[Bank.i] = new Account(name, ph, pin);
                Console.Write("account created succesfully\n your Bank.acntsount number is" + Convert.ToString(Bank.i + 1000));
            }
            else
            {
                Print("Bank account can't be created");
            }

        }
        public static void Deposit()
        {
            Print("Enter your Bank account no");
            int num = Reader.AccountRead() - 1000;
            if (num <= Bank.i)
            {
                Print("Enter the amount to deposit");
                double amt = Reader.AmountRead();
                if (amt > 0)
                {
                    Print("\nSuccessfully deposited the money and your current balance is");
                    Bank.acnts[num].history.Add(new Transaction("Done by : self", "Type : Credit", amt));
                    Print(Convert.ToString(Bank.acnts[num].SetAmount(amt, true)));
                }
                else
                    Print("Invalid amount");

            }
            else
            {
                Print("Bank account not present");
            }

        }

        public static void Withdraw()
        {
            Print("Enter your Bank account no");
            int num = Reader.AccountRead() - 1000;
            Print("Enter your pin");
            int ppin = Reader.PinRead();

            if (num <= Bank.i && Bank.acnts[num].GetPin() == ppin)
            {
                Print("Enter the amount to withdraw");
                double amt = double.Parse(Console.ReadLine());
                if (Bank.acnts[num].GetAmount() >= amt)
                {
                    Print("collect your amount");
                    Bank.acnts[num].SetAmount(amt, false);
                    Print("\nSuccessfully withdrawn the money and your current balance is");
                    Bank.acnts[num].history.Add(new Transaction("Done by : Self", "Type : Debit", amt));

                    Print(Convert.ToString(Bank.acnts[num].GetAmount()));


                }
                else
                { Print("insufficient balance"); }


            }
            else
            {
                Print("Bank account not present");
            }


        }

        public static void Transfer()
        {
            Print("Enter your Bank account no");
            int num = Reader.AccountRead() - 1000;
            Print("Enter your pin");
            int ppin = Reader.PinRead();
            if (num <= Bank.i && Bank.acnts[num].GetPin() == ppin)
            {
                Print("Enter the Bank account no to transfer");
                int acntno = Reader.AccountRead() - 1000;
                if (acntno <= Bank.i)
                {
                    Print("Enter the amount  to transfer");

                    double amt = double.Parse(Console.ReadLine());

                    if (Bank.acnts[num].GetAmount() >= amt)
                    {
                        Bank.acnts[acntno].SetAmount(amt, true);
                        Bank.acnts[num].history.Add(new Transaction("Done by : Self", "type : Debit", amt));
                        Bank.acnts[acntno].history.Add(new Transaction("Done by : "+Bank.acnts[num].name ,"type : Credit",amt));

                        Print("\nSuccessfully transferred the money and your current balance is");
                        Print(Convert.ToString(Bank.acnts[num].SetAmount(amt, false)));


                    }
                    else
                    {
                        Print("insufficient balance");
                    }
                }
                else
                {
                    Print("invalid Bank account");
                }
            }
            else
            {
                Print("Bank.acntscount may not present or your passcode is wrong");
            }
        }

        
        
        
        
        
        public static void History()
        {
            Print("Enter your Bank account no");
            int num = Reader.AccountRead() - 1000;
            Print("Enter your PIN");
            int ppin = Reader.PinRead();
            if (num <= Bank.i && Bank.acnts[num].GetPin() == ppin)
            {
                Console.Clear();
                foreach(Transaction t in Bank.acnts[num].history)
                {
                    Print(t.sender + "\t\t" + t.type + "\t\t" + Convert.ToString(t.amount));
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Print("\n\n\n\n\n\t\t\tyour current balance is   " + Bank.acnts[num].GetAmount());
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Print("invalid Bank account credentials");
            }
        }
    }
}
