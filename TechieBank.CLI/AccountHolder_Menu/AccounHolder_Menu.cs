using System;
using TechieBank.SERVICE;
using System.Collections.Generic;

namespace TechieBank.CLI
{
    class AccountHolder_Menu : Application_Menu
    {
        
  
        public static void Display()
        {
            double amt;
            Console.Clear();
            while (true)
            {
                DisplayMsgs.AccountHolderMenu();                                                   //service options
                Options choice = (Options)Enum.Parse(typeof(Options), Console.ReadLine());

                switch (choice)
                {
                    

                    case Options.deposit:                                            //deposition section
                        amt = Reader.AmountRead();
                        Print(account_service.Deposit(amt));
                        Wait();
                        break;

                    case Options.withdraw:                                          //withdraw section
                        amt = Reader.AmountRead();
                        if(amt>0)
                            Print(account_service.Withdraw(amt));
                        Wait();
                        break;


                    case Options.transfer:
                        Print("Enter debitor's Details\n");
                        Print("Enter bankid ");
                        String debitorbankid = Convert.ToString(Console.ReadLine());                        //transfer section
                        Print("Enter the accounid of debitor");
                        String debitorid = Convert.ToString(Console.ReadLine());
                        amt = Reader.AmountRead();
                        Print("Enter the mode of transfer 1.RTGS\n2.IMPS");
                        int mode = Convert.ToInt32(Console.ReadLine());
                        Print(account_service.Transfer(bank_service, debitorbankid, debitorid, amt,mode));
                        Wait();
                        break;


                    case Options.history:                                            //transaction history section
                        DisplayMsgs.HistoryPrint(account_service.History());                        
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
