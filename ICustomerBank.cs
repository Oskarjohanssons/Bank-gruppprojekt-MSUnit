using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public interface ICustomerBank 
    {

        public static void Deposit(Customer currentUser)
        {
        }

        public void AddAccount(string accountType, double initialBalance, string currency)
        {
        }

        public void DisplayAccounts(Customer user)
        {     
        }
            
        public static void AddNewAccount(Customer current)
        {
        }

        public static void TransferMoney(Customer currentUser, List<Customer> allUsers)
        {
        }

        private static void TransferBetweenOwnAccounts(Customer currentUser)
        {        
        }

        private static void TransferToAnotherUser(Customer currentUser, List<Customer> allUsers)
        {           
        }
        public static void DisplayUsers(List<Customer> users)
        {
        }
        public static void PrintLogBois()
        {
        }
    }
}

