using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < new Random().Next(2,10); i++)
            {
                GetAccount(new Account(), new Random().Next(100000) / 100m, AccountType.CurrentAccounts);
            }

            void GetAccount(Account account, decimal balance, AccountType type)
            {
                account.SetNumber();
                account.SetBalance(balance);
                account.SetAccountType(type);

                Console.WriteLine($"Счет: {account.GetNumber()}");
                Console.WriteLine($"Тип счета: {account.GetAccountType()}");
                Console.WriteLine($"Баланс счета: {account.GetBalance()}");
                Console.WriteLine();
            }
        }
    }
}