using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Account
    {
       
        public string Accounttype { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public double IntrestRate { get; set; } 


        public Account(string accountType, double balance, string currency)
        {
            Accounttype = accountType;
            Balance = balance;            
            Currency = currency;
        }

    }
}