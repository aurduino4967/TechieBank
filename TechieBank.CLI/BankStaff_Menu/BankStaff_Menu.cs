using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;
namespace TechieBank.CLI
{
    class BankStaffMenu
    {
        public static void Wait()
        { Console.ReadKey(true); }
        public static void BankStaffMenuDisplay()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                DisplayMsgs.BankStaffMenu();
                BankStaffOpt choice = (BankStaffOpt)Enum.Parse(typeof(BankStaffOpt), Console.ReadLine());

                switch (choice)
                {
                    case BankStaffOpt.CreateAccount:
                        BankStaffService.Create();
                        Wait();
                        break;

                    case BankStaffOpt.DeleteAccount:
                        BankStaffService.Delete();
                        Wait();
                        break;

                    case BankStaffOpt.ChangeTransferRates:
                        BankStaffService.ChangeTransferRates();
                        Wait();
                        break;


                    case BankStaffOpt.ChangeCurrency:
                        BankStaffService.ChangeCurrency();
                        Wait();
                        break;

                    case BankStaffOpt.RevertTransaction:
                        BankStaffService.RevertTransaction();
                        Wait();
                        break;
                    case BankStaffOpt.AccountTransaction:
                        BankStaffService.History();
                        Wait();
                        break;

                    case BankStaffOpt.exit:
                        Application_Menu.Main();
                        break;


                }
            }
        }
    }
}
