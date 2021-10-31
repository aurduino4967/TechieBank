using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;

namespace TechieBank.CLI
{
    class Application_Menu
    {
        public static BankService bank_service = new BankService();
        public static AccountService account_service = new AccountService();
        public static BankStaffService bank_staff_service = new BankStaffService();
        public static void Print(String msg)
        {
            Console.WriteLine(msg);
        }
        public static void Wait()
        { Console.ReadKey(true); }
        public static void Main()
        {
              
            while (true)
            {
                Console.Clear();
                DisplayMsgs.ApplicationMenu();
                ApplicationMenuOpt choice = (ApplicationMenuOpt)Enum.Parse(typeof(ApplicationMenuOpt), Console.ReadLine());

                switch (choice)
                {


                    case ApplicationMenuOpt.CreateBank:
                        Print("Enter Bank name");
                        String name = Convert.ToString(Console.ReadLine());
                        Print("Enter IFSC CODE");
                        String ifsc = Convert.ToString(Console.ReadLine());
                        Print( bank_service.Create(name, ifsc));
                        Wait();
                        break;

                    case ApplicationMenuOpt.BankStaff:
                        String bank_id = Reader.BankRead();
                        Print("Enter Passcode for Staff");
                        String staff_code = Convert.ToString(Console.ReadLine());
                        if (bank_staff_service.ValidateStaff(bank_service, bank_id, staff_code))
                        {
                            BankStaffMenu.BankStaffMenuDisplay();
                        }
                        else
                        { Print("Inalid Credentials\n"); }
                        break;

                    case ApplicationMenuOpt.LoginToAccount:
                        Print("enter bank id");
                        String bankid = Convert.ToString(Console.ReadLine());
                        Print("Enter account id");
                        String acc_id = Convert.ToString(Console.ReadLine());
                        Print("Enter PIN");
                        int pin = Convert.ToInt32(Console.ReadLine());
                        if (account_service.AccountValidate(bank_service,bankid,acc_id,pin))
                        {
                            AccountHolder_Menu.Display();
     
                        }
                        Wait();
                        break;


                    case ApplicationMenuOpt.exit:
                        System.Environment.Exit(0);
                        break;


                }
            }
        }
    }
}
