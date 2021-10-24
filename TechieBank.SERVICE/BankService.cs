using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;
namespace TechieBank.SERVICE
{
    public class BankService
    {
        public static void Print(String msg)
        { Console.WriteLine(msg); }
        public static List<Bank> Banks = new List<Bank>();
        public static void Create()
        {
            Print("Enter Bank name");
            String name = Convert.ToString(Console.ReadLine());
            Bank k = new Bank(name);
            Banks.Add(k);
            Print("Bank created successfully"+"and Bank_id is :  "+ k.id);
        }
        public static Bank GetBank()
        {
            String Bank_id = Reader.BankRead();
            return  BankService.Banks.SingleOrDefault(o => o.id == Bank_id);

        }


    }
}
