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
            public static void AccountHolderMenu()
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
            
            public static void BankStaffMenu()
        {
            Print("\t\t1. CREATE ACCOUNT\n");
            Print("\t\t2. Delete \n");
            Print("\t\t3. exit \n");
        }
        public static void ApplicationMenu()
        {
            Print("\t\t1. CreateBank\n");
            Print("\t\t2. BankStaff\n");
            Print("\t\t3. LoginToAccount \n");
            Print("\t\t4. exit \n");
        }

    }
}

