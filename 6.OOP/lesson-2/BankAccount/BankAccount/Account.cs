using System;

namespace BankAccount
{
    public class Account
    {
        private uint _number;
        private decimal _balance = 0.00m;
        private AccountType _type;
        private static uint _lastNumber = 1;

        public Account(decimal balance)
        {
            Number = GenerateNumber();
            Balance = balance;
        }

        public Account(AccountType type)
        {
            Number = GenerateNumber();
            Type = type;
        }

        public Account(decimal balance, AccountType type)
        {
            Number = GenerateNumber();
            Balance = balance;
            Type = type;
        }

        private static uint GenerateNumber()
        {
            return _lastNumber++;
        }

        public uint Number
        {
            get => _number;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _number = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _balance = value;
            }
        }

        public AccountType Type
        {
            get => _type;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _type = value;
            }
        }

        public string Deposit(decimal value)
        {
            Balance += value;
            return $"Операция выполнена успешно. Баланс: {Balance}";
        }

        public string Withdraw(decimal value)
        {
            if (Balance - value > 0)
            {
                Balance -= value;
                return $"Операция выполнена успешно. Баланс: {Balance}";
            }

            return $"Недостаточно средств. Операция не выполнена. Баланс:{Balance}";
        }
    }
}