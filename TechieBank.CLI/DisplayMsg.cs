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
            Print("\t\t1. Create Account\n");
            Print("\t\t2. Delete Account\n");
            Print("\t\t3. ChangeTransferRates\n");
            Print("\t\t4. ChangeCurrency\n");
            Print("\t\t5. RevertTransaction\n");
            Print("\t\t6. AccountTransaction History\n");
            Print("\t\t7. exit \n");
            Print("\n\nChoose your option\n");
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

