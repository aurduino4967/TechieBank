using System;
using TechieBank.MODEL;
using System.Linq;
using System.Collections.Generic;


namespace TechieBank.SERVICE
{
    public class AccountService
    {
        public Bank CurBank;
        public  Account acc;
        public  int pin;
       
        public  bool AccountValidate(BankService bank_service,String bankid,String acc_id,int pin)
        {
            CurBank = bank_service.Banks.SingleOrDefault(o => o.id == bankid);
            
            
            if (CurBank!=null)
            {
                
                acc = CurBank.acnts.SingleOrDefault(o => o.id == acc_id);
                if (acc != null && acc.GetPin() == pin)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public  String Deposit(double amt)
        {

            if (amt <= 0)
                return "invalid amount";
            acc.SetAmount(amt, true);
            acc.history.Add(new Transaction(acc.Bank_id + acc.id+acc.tid, "Done by : Self","deposited", "Type : Credit", amt));
            acc.tid += 1;
            return "successfull";
            

        }

        


        public  String Withdraw(double amt)
        {
            if (acc.GetAmount() < amt)
                return "insufficient balance";
            
                acc.SetAmount(amt, false);    
                acc.history.Add(new Transaction(acc.Bank_id+acc.id+acc.tid, "Done by : Self","Withdrawn", "Type : Debit", amt));
                acc.tid += 1;
            return "Collect your amount";
        }

        public String Transfer(BankService bank_service, String bankid, String debitorid, double amt,int t)
        {
            Bank debitors = bank_service.Banks.SingleOrDefault(o => o.id == bankid);
            Account debitor = debitors.acnts.SingleOrDefault(o => o.id == debitorid);
            if (debitor == null  )
                return "beneficiary account not present";
            if (acc.GetAmount() < amt || amt <=0 )
                return "balance insufficiency";
            if (t != 1 && t != 2)
                return "invalid mode of transfer";
                string eqornoteq = acc.Bank_id == debitor.Bank_id ? "SAME" : "DIFF";
                 double temp;
            
                    Bank k = bank_service.Banks.SingleOrDefault(o => o.id == acc.Bank_id);
                    string mode = t == 1 ? "RTGS" : "IMPS";
                    temp = t == 1 ? amt * (k.RTGS[eqornoteq]) / 100 : amt * (k.IMPS[eqornoteq]) / 100;
                    debitor.SetAmount(amt - temp, true);
                    acc.SetAmount(amt, false);
                    acc.history.Add(new Transaction(acc.Bank_id + acc.id + acc.tid, "Done by : Self  ", "transferred to : " + debitor.id, "type : Debit", amt));
                    debitor.history.Add(new Transaction(acc.Bank_id + acc.id + acc.tid, "transferred by : " + acc.id, "\tmode of transfer : " + mode + "charges incurred: " + Convert.ToString(temp), "type : Credit", amt - temp));
                    acc.tid += 1;


            return "done successfull";
        }





        public List<String> History()
        {
            

            List<String> transactions = new List<string>();

            foreach (Transaction t in acc.history)
            {
                transactions.Add(t.id + " " + t.sender + " " + t.statement + " " + Convert.ToString(t.amount));
            }
            transactions.Add("\n\nyour balance is \t :  " + Convert.ToString(acc.GetAmount()));

            return transactions;

        }
    }
}