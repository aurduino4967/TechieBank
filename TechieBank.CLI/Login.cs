using System;
using TechieBank.SERVICE;

namespace TechieBank.CLI
{
    class Login
    {
        
        public  static void Wait()
        {
           Console.ReadKey(true);
        }
   
        public static void Useropt()
        {
            Console.Clear();
            while (true)
            {
                DisplayMsgs.ServiceOpt();                                                   //service options
                Options choice = (Options)Enum.Parse(typeof(Options), Console.ReadLine());

                switch (choice)
                {
                    

                    case Options.deposit:                                          //deposition section
                        Service.Deposit();
                        Wait();
                        break;

                    case Options.withdraw:                                          //withdraw section
                        Service.Withdraw();
                        Wait();

                        break;


                    case Options.transfer:                                           //transfer section
                        Service.Transfer();
                        Wait();
                        break;


                    case Options.history:                                            //transaction history section
                        Service.History();
                        Wait();
                        break;


                    case Options.exit:                                               //exit section
                        MainScreen.Main();
                        break;
   


                }
            }
        }
    }

}
