using System;
using TechieBank.SERVICE;

namespace TechieBank.CLI
{
    class Program
    {
        
        public static void Wait()
        {
            Console.ReadKey(true);
        }
   
        public static void Main()
        {
            int choice;
            Option.Bankdisplay();
            while (true)
            {
                Option.ServiceOpt();                                                    //service options

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (int)opt.create:                                            //account creation
                        Service.Create();
                        Wait();
                        break;

                    case (int)opt.deposit:                                          //deposition section
                        Service.Deposit();
                        Wait();
                        break;



                    case (int)opt.withdraw:                                          //withdraw section
                        Service.Withdraw();
                        Wait();

                        break;



                    case (int)opt.transfer:                                           //transfer section
                        Service.Transfer();
                        Wait();
                        break;

                    case (int)opt.history:                                            //transaction history section
                        Service.History();
                        Wait();
                        break;


                    case (int)opt.exit:                                                        //exit section
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }

}
