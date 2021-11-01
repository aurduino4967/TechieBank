using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;
namespace TechieBank.CLI
{
    class BankStaffMenu : Application_Menu
    {
  
        public static void Display()
        {
            Console.Clear();
            try
            {
                while (true)
                {
                    Console.Clear();
                    DisplayMsgs.BankStaffMenu();
                    BankStaffOpt choice = (BankStaffOpt)Enum.Parse(typeof(BankStaffOpt), Console.ReadLine());

                    switch (choice)
                    {
                        case BankStaffOpt.CreateAccount:
                            Print("Enter the name");
                            String name = ReadString();
                            Print("Enter phone number");
                            String ph = ReadString();
                            Print("Enter pincode");
                            int pin = ReadInt();
                            Print(bank_staff_service.Create(name, ph, pin));
                            Wait();
                            break;

                        case BankStaffOpt.DeleteAccount:
                            Print("enter the account id");
                            String accid = ReadString();
                            bank_staff_service.Delete(accid);
                            Wait();
                            break;

                        case BankStaffOpt.ChangeTransferRates:
                            Print("change of transfer rates to be done on \n1.RTGS\n2.IMPS\nchoose your option");
                            int temp = Convert.ToByte(Console.ReadLine());
                            Print("Enter the transfer charges for RTGS MODE of transfer");
                            double one = Convert.ToDouble(Reader.AmountRead());
                            Print("Enter the transfer charges for IMPS MODE of transfer");
                            double two = ReadDouble();
                            Print(bank_staff_service.ChangeTransferRates(temp, one, two));
                            Wait();
                            break;


                        case BankStaffOpt.ChangeCurrency:
                            String currency = ReadString();
                            Print(bank_staff_service.ChangeCurrency(currency));
                            Wait();
                            break;

                        case BankStaffOpt.RevertTransaction:
                            Print("enter the account id");
                            accid = ReadString();
                            Print("Enter the transaction id");
                            String t = ReadString();
                            Print(bank_staff_service.RevertTransaction(bank_service, accid, t));
                            Wait();
                            break;

                        case BankStaffOpt.AccountTransaction:
                            DisplayMsgs.HistoryPrint(bank_staff_service.History(Reader.AccountRead()));
                            Wait();
                            break;

                        case BankStaffOpt.exit:
                            Application_Menu.Main();
                            break;


                    }
                }
            }
            catch
            {
                Print("invalid");
                Wait();
                Display();
            }
        }
    }
}
