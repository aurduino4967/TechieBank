using System;
using System.Collections.Generic;
using System.Text;

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
                Print("WELCOME TO TECHIE'S BANK ATM SERVICE\n");
                Print("\t\t1. DEPOSIT \n");
                Print("\t\t2. WITHDRAW \n");
                Print("\t\t3. TRANSFER\n");
                Print("\t\t4. TRANSACTION HISTORY\n");
                Print("\t\t5. EXIT");
                Print("********************************\n\n");
                Print("ENTER YOUR CHOICE : ");
            }
            public static void Bankdisplay()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Print("\n\n\n\n\n\n\n\n\n\t\t\t*************************************TECHIE'S BANK*******************************");
                Print("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tenter a key to continue...");
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.White;
            }
            public static void MainScreenOpt()
        {
            Print("WELCOME TO TECHIE'S BANK ATM SERVICE\n");
            Print("\t\t1. CREATE ACCOUNT\n");
            Print("\t\t2. login \n");
            Print("\t\t3. exit \n");
        }
    }
}

