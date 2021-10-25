using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;

namespace TechieBank.SERVICE
{
    public class BankStaffService
    {
        public static Bank current;
        public static void Print(String msg)
        { Console.WriteLine(msg); }

        public static void ChangeTransferRates()
        {
            Print("Want to change the rates for \n1.same bank  \n2.different bank");
            int t = Convert.ToInt16(Console.ReadLine());
            if (t==1)
            { SameBank_ChangeTransferRates(); }
            else if(t==2)
            { DiffBank_ChangeTransferRates(); }
            else
            { Print("invalid option selection"); }
            
        }
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
        public static void ChangeCurrency()
        {
            Print("Enter the currency");
            current.currency = Console.ReadLine();
            
        }
        public static void SameBank_ChangeTransferRates()
        {
            Print("Enter the charges for RTGS transfer");
            current.RTGS["SAME"] = Convert.ToDouble(Console.ReadLine());
            Print("Enter the charges for IMPS transfer");
            current.IMPS["SAME"] = Convert.ToDouble(Console.ReadLine());

             
        }
        public static void History()
        {

            Account acc = Reader.AccountRead(current);
            Console.Clear();
            if (acc != null)
            {
                foreach (Transaction t in acc.history)
                {
                    Print("TRANSACTION ID : " + t.id + "\t" + t.sender + "\t" + t.type + t.statement + "  amount : " + Convert.ToString(t.amount));
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Print("\n\n\n\n\n\t\t\tyour current balance is   " + acc.GetAmount());
                Console.ForegroundColor = ConsoleColor.White;

            }
            else { Print("account credentials invalid"); }
        }
        public static void DiffBank_ChangeTransferRates()
        {
            Print("Enter the charges for RTGS transfer");
            current.RTGS["SAME"] = Convert.ToDouble(Console.ReadLine());
            Print("Enter the charges for IMPS transfer");
            current.IMPS["SAME"] = Convert.ToDouble(Console.ReadLine());

        }
        public static void RevertTransaction()
        {
            Print("Enter the details of the creditor");
            Account acc = Reader.AccountRead(current);
            Print("Enter Transaction Id");
            String temp = Convert.ToString(Console.ReadLine());
            Transaction t = acc.history.SingleOrDefault(o => o.id == temp);
            if (t!=null)
            {
                Account sender = current.acnts.SingleOrDefault(o => o.id == t.sender.Substring(17,11));
                if (sender != null)
                {
                    acc.SetAmount(t.amount, false);
                    sender.SetAmount(t.amount, true);
                    sender.history.Remove(t);
                    acc.history.Remove(t);
                    Print("transaction reverted");


                }
                else
                {
                    Print("transaction can't be reverted becaus creditors account is invalid");
                }

                

            }
            else
            {
                Print("Transaction id can't be found");
            }

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
				    Print("Account id is : " + created.id);
				    Print("Passcode is : " + Convert.ToString(created.GetPin()));
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
