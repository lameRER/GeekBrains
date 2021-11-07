using System;

namespace BankAccount
{
    public class Account
    {
        private uint _number;
        private decimal _balance;
        private AccountType _type;

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

        public void SetNumber(uint number)
        {
            Number = number;
        }

        public void SetBalance(decimal balance)
        {
            Balance = balance;
        }

        public void SetAccountType(AccountType type)
        {
            Type = type;
        }

        public uint GetNumber() => _number;
        
        public decimal GetBalance() => _balance;

        public AccountType GetAccountType() => _type;
    }
}