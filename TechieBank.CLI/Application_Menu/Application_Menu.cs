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
            Console.Clear();
            DisplayMsgs.BankService();
            while (true)
            {
                Console.Clear();
                DisplayMsgs.BankService();
                BankServiceOpt choice = (BankServiceOpt)Enum.Parse(typeof(BankServiceOpt), Console.ReadLine());

                switch (choice)
                {


                    case BankServiceOpt.Create:
                        BankService.Create();
                        Wait();
                        break;

                    case BankServiceOpt.Goto:
                            Bank_Menu.BankMenuDisplay();
                            Login.Useropt();
                            Wait();

                        break;


                    case BankServiceOpt.exit:
                        System.Environment.Exit(0);
                        break;


                }
            }
        }
    }
}
