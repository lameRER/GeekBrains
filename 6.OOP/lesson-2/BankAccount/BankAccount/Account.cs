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

        private uint Number
        {
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _number = value;
            }
        }

        private decimal Balance
        {
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _balance = value;
            }
        }

        private AccountType Type
        {
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _type = value;
            }
        }

        public uint GetNumber() => _number;

        public decimal GetBalance() => _balance;

        public AccountType GetAccountType() => _type;
    }
}