﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TechieBank.CLI
{
    public enum BankStaffOpt
        {
        CreateAccount=1,
        DeleteAccount,
        ChangeTransferRates,
        ChangeCurrency,
        RevertTransaction,
        AccountTransaction,
        exit
    }
}
