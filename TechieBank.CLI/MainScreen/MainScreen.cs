using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;
namespace TechieBank.CLI
{
    class MainScreen
    {
        public static void Wait()
        { Console.ReadKey(true); }
        public static void Main()
        {
            DisplayMsgs.Bankdisplay();
            while(true)
            { 
            Console.Clear();
            DisplayMsgs.MainScreenOpt();
            MainScreenOpt choice = (MainScreenOpt)Enum.Parse(typeof(MainScreenOpt), Console.ReadLine());

            switch (choice)
            {


                case MainScreenOpt.create:
                    Service.Create();
                    Wait();
                    break;

                case MainScreenOpt.login:
                        if (Service.AccountValidate())
                        {
                            Login.Useropt();
                            Wait();

                        }
                        break;


                case MainScreenOpt.exit:
                    System.Environment.Exit(0);
                    break;


            }
                }
        }
    }
}
