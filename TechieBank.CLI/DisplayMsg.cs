using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.SERVICE;
namespace TechieBank.CLI
{
    class DisplayMsgs
    {
            public static void Print(String msg)
            {
                Console.WriteLine(msg);
            }
            public static void ServiceOpt()
            {
                Console.Clear();
                Print("\t\t1. DEPOSIT \n");
                Print("\t\t2. WITHDRAW \n");
                Print("\t\t3. TRANSFER\n");
                Print("\t\t4. TRANSACTION HISTORY\n");
                Print("\t\t5. EXIT");
                Print("********************************\n\n");
                Print("ENTER YOUR CHOICE : ");
            }
            
            public static void MainScreenOpt()
        {
            Print("\t\t1. CREATE ACCOUNT\n");
            Print("\t\t2. login \n");
            Print("\t\t3. exit \n");
        }
        public static void BankService()
        {
            Print("\t\t1. CREATE BANK\n");
            Print("\t\t2. Accounts and Service \n");
            Print("\t\t3. exit \n");
        }

    }
}

