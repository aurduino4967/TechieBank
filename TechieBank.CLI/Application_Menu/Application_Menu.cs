using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;

namespace TechieBank.CLI
{
    class Application_Menu
    {
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
                        BankService.Create();
                        Wait();
                        break;

                    case ApplicationMenuOpt.BankStaff:
                        if(BankStaffService.ValidateStaff())
                        {
                            BankStaffMenu.BankStaffMenuDisplay();
                        }
                     
                         
                        break;

                    case ApplicationMenuOpt.LoginToAccount:
                        if (AccountService.AccountValidate())
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
