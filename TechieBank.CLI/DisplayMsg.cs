using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.CLI
{
    class Option
    {

            public static void Print(String msg)
            {
                Console.WriteLine(msg);
            }
            public static void ServiceOpt()
            {
                Console.Clear();
                Print("WELCOME TO TECHIE'S BANK ATM SERVICE\n");
                Print("\t\t1. CREATE ACCOUNT\n");
                Print("\t\t2. DEPOSIT \n");
                Print("\t\t3. WITHDRAW \n");
                Print("\t\t4. TRANSFER\n");
                Print("\t\t5. TRANSACTION HISTORY\n");
                Print("\t\t6. EXIT");
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
    }
}

