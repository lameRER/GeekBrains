﻿using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var balance = new Random().Next(999999)/ 100m;
                GetAccount(new Account(balance));
                GetAccount(new Account(AccountType.CurrentAccounts));
                GetAccount(new Account(balance, AccountType.CurrentAccounts));

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