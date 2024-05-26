using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Administrator : User , IMenuServices
    {
        public const int MaxLoginAttempts = 3;
        public static double usdToSekRate = 10;
        private static double sekToUsdRate = 1 / usdToSekRate;

        public static double SavingsInterestRate { get; private set; } = 0.2;
        public Administrator(string userName, string pin) : base(userName, pin)
        {

        }

        private static List<Administrator> Administrators;
        static Administrator()
        {

            Administrators = new List<Administrator>
            {
            new Administrator("Karen", "0000"),
            new Administrator("Admin", "7777")

            };
        }

        public static void DisplayInterest(string accountType)
        {

            Console.WriteLine($"By opening a new {accountType} account, you will receive an interest of {SavingsInterestRate}.");
        }


        public static double GetExchangeRate(string sourceCurrency, string targetCurrency)
        {
            if (sourceCurrency == "USD" && targetCurrency == "SEK")
            {
                return usdToSekRate;
            }

            if (sourceCurrency == "SEK" && targetCurrency == "USD")
            {
                return 1 / usdToSekRate;
            }
            return 1.0;
        }

        public void SetExchangeRate(string sourceCurrency, string targetCurrency, double newRate)
        {
            if (sourceCurrency == "USD" && targetCurrency == "SEK")
            {
                usdToSekRate = newRate;
            }

            if (sourceCurrency == "SEK" && targetCurrency == "USD")
            {
                sekToUsdRate = 1 / newRate;
            }
        }
        public void AdminCreateUser(Administrator adminUser)
        {
            Console.Clear();           
            Console.WriteLine("Admin Console - Create New User");
            Console.WriteLine("-------------------------------");

            Console.Write("Enter username of new User (letters only): ");
            string username = Console.ReadLine();
            Console.Write("Enter a four digit pin code (numbers only): ");
            string pin = Console.ReadLine();
            if (pin.Length != 4 || !int.TryParse(pin, out _))
            {
                Console.WriteLine("\u001b[31mInvalid PIN format. Please enter a valid four-digit PIN.\u001b[0m");
                Console.WriteLine();
            }
            if (username.Length != 2 && username.Count(char.IsLetter) < 2)
            {
                Console.WriteLine("\u001b[31mInvalid Username format. Username must be atleast 2 letters.\u001b[0m");
                Console.WriteLine();
            }

            Customer newUser = CreateUser(username, pin);

            if (newUser != null)
            {
                Customer.AddUser(newUser);
                Console.WriteLine($"User created successfully: {newUser.Username}, PIN: {newUser.Pin}");
            }
            else
            {
                Console.WriteLine("\u001b[31mUser creation failed. Please check the input and try again.\u001b[0m");
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit to Menu");
            Console.ReadLine();
            Console.Clear();
        }


        public Customer CreateUser(string username, string pin)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Count(char.IsLetter) < 2 || pin.Length != 4 || !pin.All(char.IsDigit))
            {
                Console.WriteLine("Invalid input for creating a new user. Please provide a valid username with atleast two letters and a four-digit PIN 0000-9999");
                return null;
            }

            if (Customer.GetCustomerWithAccounts().Any(u => u.Username == username))
            {
                Console.WriteLine($"Username '{username}' is already taken. Please choose a different username.");
                return null;
            }

            Customer newUser = new Customer(username, pin);

            Console.WriteLine($"New user created: {newUser.Username} with PIN: {pin}");

            return newUser;
        }

        public void AdminDeleteAccount(Administrator currentAdmin)
        {
            Console.Clear();
            Console.Write("Enter the username of the user whose account you want to delete: ");
            string targetUsername = Console.ReadLine();
            Customer targetUser = Customer.GetCustomerWithAccounts().FirstOrDefault(u => u.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase));

            if (targetUser != null)
            {
                Console.WriteLine($"Accounts for user '{targetUsername}':");
                for (int i = 0; i < targetUser.Accounts.Count; i++)
                {
                    var account = targetUser.Accounts[i];
                    Console.WriteLine($"{i + 1}. [{account.Accounttype}] {account.Balance} {account.Currency}");
                }

                Console.Write("Enter the number of the account you want to delete: ");
                if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= targetUser.Accounts.Count)
                {
                    string accountNameToDelete = targetUser.Accounts[selectedIndex - 1].Accounttype;
                    AdminDeleteAccount(targetUser, accountNameToDelete, currentAdmin);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine($"User '{targetUsername}' not found.");
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit to Menu");
            Console.ReadLine();
            Console.Clear();
        }




        private void AdminDeleteAccount(Customer user, string accountName, Administrator currentAdmin)
        {
            if (user == null || !Administrators.Contains(currentAdmin))
            {
                Console.WriteLine("Insufficient privileges. Only admins can delete accounts.");
                return;
            }

            Customer targetUser = Customer.GetCustomerWithAccounts().FirstOrDefault(u => u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));

            if (targetUser == null)
            {
                Console.WriteLine($"User '{user.Username}' not found.");
                return;
            }

            Account targetAccount = targetUser.Accounts.FirstOrDefault(a => a.Accounttype.Equals(accountName, StringComparison.OrdinalIgnoreCase));

            if (targetAccount == null)
            {
                Console.WriteLine($"Account '{accountName}' not found for user '{user.Username}'.");
                return;
            }

            if (targetAccount.Balance != 0)
            {
                Console.WriteLine($"Cannot delete account '{accountName}' for user '{user.Username}' because its not empty.");
                return;
            }

            targetUser.Accounts.Remove(targetAccount);
            Console.WriteLine($"Account '{accountName}' deleted successfully for user '{user.Username}'.");
            Thread.Sleep(3000);
            Console.Clear();
        }

        public static void Menu(Administrator currentAdmin)
        {

            Console.Clear();
            int option = 0;

            do
            {
                PrintOptions(currentAdmin);
                try
                {
                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        switch (option)
                        {
                            case 1:
                                currentAdmin.AdminCreateUser(currentAdmin);
                                break;
                            case 2:
                                currentAdmin.AdminDeleteAccount(currentAdmin);
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("\u001b[31mExiting...\u001b[0m");
                                Console.WriteLine("");
                                Console.WriteLine("Press enter to exit to Login");
                                Console.ReadLine();
                                Console.Clear();
                                AviciiBank art = new AviciiBank();
                                art.PaintBank();
                                break;
                            default:
                                Console.WriteLine("Invalid option. Try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1, 2 or 3.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            } while (option != 3);
        }

        public static void PrintOptions(Administrator currentAdmin)
        {

            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║        Administrator Menu        ║");
            Console.WriteLine("╠══════════════════════════════════╣");
            Console.WriteLine("║ 1. Create User                   ║");
            Console.WriteLine("║ 2. Delete Account                ║");
            Console.WriteLine("║ 3. Exit                          ║");
            Console.WriteLine("╚══════════════════════════════════╝");
        }

        public static Administrator AuthenticateAdministrator(string username, string pin)
        {


            if (int.TryParse(pin, out int pinValue))
            {


                Administrator authenticatedAdministrator = Administrators.FirstOrDefault(u => u.Username.Trim().Equals(username, StringComparison.OrdinalIgnoreCase) && u.Pin.ToString() == pin);

                if (authenticatedAdministrator != null)
                {
                    Console.WriteLine($"\t\u001b[32mAuthentication successful for administrator: {username}\u001b[0m");
                }
                return authenticatedAdministrator;
            }
            else
            {
                return null;
            }
        }

    }
}