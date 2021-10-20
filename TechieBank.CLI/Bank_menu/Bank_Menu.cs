using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;
namespace TechieBank.CLI
{
    class Bank_Menu
    {
        public static void Wait()
        { Console.ReadKey(true); }
        public static void BankMenuDisplay()
        {
            Console.Clear();
            while(true)
            { 
            Console.Clear();
            DisplayMsgs.MainScreenOpt();
            MainScreenOpt choice = (MainScreenOpt)Enum.Parse(typeof(MainScreenOpt), Console.ReadLine());

            switch (choice)
            {


                case MainScreenOpt.create:
                    AccountService.Create();
                    Wait();
                    break;

                case MainScreenOpt.login:
                        if ( AccountService.AccountValidate())
                        {
                            Login.Useropt();
                            Wait();

                        }
                        break;


                case MainScreenOpt.exit:
                        Application_Menu.Main();
                    break;


            }
                }
        }
    }
}
