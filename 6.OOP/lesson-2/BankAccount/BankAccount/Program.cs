using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            account.SetNumber(123);
            account.SetBalance(500.00m);
            account.SetAccountType(AccountType.CurrentAccounts);

            Console.WriteLine($"Счет: {account.GetNumber()}");
            Console.WriteLine($"Тип счета: {account.GetAccountType()}");
            Console.WriteLine($"Баланс счета: {account.GetBalance()}");
        }
    }
}