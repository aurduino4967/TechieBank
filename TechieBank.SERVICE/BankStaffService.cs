using System;
using System.Collections.Generic;
using System.Text;
using TechieBank.MODEL;
using System.Linq;
using System.Text.RegularExpressions;

namespace TechieBank.SERVICE
{
    public class BankStaffService
    {
        public Bank current;
    
        public String ChangeTransferRates(int t,double one,double two)
        {
            
            if (t==1)
            { SameBank_ChangeTransferRates(one,two); }
            else if(t==2)
            { DiffBank_ChangeTransferRates(one,two); }
            else
            { return "invalid option";  }
            return "successfull";
            
        }
        public  bool ValidateStaff(BankService obj,String bank_id,String passcode)
        {
            current = obj.GetBank(bank_id);
            if (current != null && current.StaffPassCode == passcode)
            {
                    return true;
            }
            return false;    
        }
        public  void ChangeCurrency(String cur)
        {
            current.currency = cur;   
        }
        public  void SameBank_ChangeTransferRates(double one,double two)
        {
            current.RTGS["SAME"] = one;   
            current.IMPS["SAME"] = two;
        }
        public List<String> History(String accid)
        {
            Account acc = current.acnts.SingleOrDefault(o => o.id == accid);
            List<String> transactions = new List<string>();

            foreach (Transaction t in acc.history)
            {
                transactions.Add(t.id + " " + t.sender + " " + t.statement + " " + Convert.ToString(t.amount));
            }
            transactions.Add("\n\nyour balance is \t :  " + Convert.ToString(acc.GetAmount()));
            return transactions;

        }
        public  void DiffBank_ChangeTransferRates(double one,double two)
        {
            current.RTGS["SAME"] = one;
            current.IMPS["SAME"] = two;
        }
        public String RevertTransaction(BankService bank_service,String accid, String temp)
        {
            Bank dbank = bank_service.Banks.SingleOrDefault(o=>o.id==temp.Substring(3, 11));
            if (dbank != null)
            {
                Account acc = current.acnts.SingleOrDefault(o => o.id == accid);
                Transaction t = acc.history.SingleOrDefault(o => o.id == temp);
                if (acc != null && t != null)
                {
                    Account sender = dbank.acnts.SingleOrDefault(o => o.id == t.sender.Substring(17, 11));
                    if (sender != null)
                    {
                        acc.SetAmount(t.amount, false);
                        sender.SetAmount(t.amount, true);
                        t = sender.history.SingleOrDefault(o => o.id == temp);
                        sender.history.Remove(t);
                        t = acc.history.SingleOrDefault(o => o.id == temp);
                        acc.history.Remove(t);
                        return "Transaction reverted successfully";

                    }
                    else
                    { return "sender account not present"; }


                }
                else { return "account not present"; }
            }
            return "invalid transaction id";
        }
        public  String  Create(String name,String ph,int pin)
        {
      
                if (pin<1000 || pin>=10000 || ph.Length!=10 || !(Regex.IsMatch(ph, @"^[0-9]+$")) || !(Regex.IsMatch(name, @"^[a-zA-Z]+$")) || name.Length<3)
                    return "Account not created due to invalid credential format";

                Account created = new Account(current.id, name, ph, pin);
                current.acnts.Add(created);
                return "account created successfully \n account id is\t"+created.id+"\npasscode is\t"+Convert.ToString(created.GetPin());
                
            

        }

        public String Delete(String accid)
        {
            Account acc = current.acnts.SingleOrDefault(o => o.id == accid);
            current.acnts.Remove(acc);
            return "account deletionn successfull";
        }
    }
}
