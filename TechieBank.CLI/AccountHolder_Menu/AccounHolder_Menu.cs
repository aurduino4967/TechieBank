using System;
using TechieBank.SERVICE;

namespace TechieBank.CLI
{
    class AccountHolder_Menu
    {
        
        public  static void Wait()
        {
           Console.ReadKey(true);
        }
   
        public static void Display()
        {
            Console.Clear();
            while (true)
            {
                DisplayMsgs.AccountHolderMenu();                                                   //service options
                Options choice = (Options)Enum.Parse(typeof(Options), Console.ReadLine());

                switch (choice)
                {
                    

                    case Options.deposit:                                          //deposition section
                        AccountService.Deposit();
                        Wait();
                        break;

                    case Options.withdraw:                                          //withdraw section
                        AccountService.Withdraw();
                        Wait();

                        break;


                    case Options.transfer:                                           //transfer section
                        AccountService.Transfer();
                        Wait();
                        break;


                    case Options.history:                                            //transaction history section
                        AccountService.History();
                        Wait();
                        break;


                    case Options.exit:                                               //exit section
                        Application_Menu.Main();
                        break;
   


                }
            }
        }
    }

}
