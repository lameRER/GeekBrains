using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var ListAccount = new List<Account>();
            var balance = new Random().Next(999999) / 100m;
            ListAccount.Add(new Account(balance));
            ListAccount.Add(new Account(AccountType.CurrentAccounts));
            ListAccount.Add(new Account(balance, AccountType.CurrentAccounts));

            for (int i = 0; i < 3; i++)
            {
                GetAccount(ListAccount[i]);
                Console.WriteLine($"Операция: снятие со счета. {ListAccount[i].Withdraw(new Random().Next(10, 1000))}");
                Console.WriteLine($"Операция: пополнения счета. {ListAccount[i].Deposit(new Random().Next(10, 1000))}");
                Console.WriteLine();
            }
            
            void GetAccount(Account account)
            {
                Console.WriteLine($"Счет: {account.Number}");
                Console.WriteLine($"Тип счета: {account.Type}");
                Console.WriteLine($"Баланс счета: {account.Balance}");
                Console.WriteLine();
            }
        }
    }
}