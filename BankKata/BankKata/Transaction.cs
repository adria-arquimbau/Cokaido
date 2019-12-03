using System;
using BankKata.Tests;

namespace BankKata
{
    public class Transaction
    {
        private readonly decimal _amount;
        private readonly DateTime _date;
        private readonly TransactionType _type;

        public Transaction(decimal amount, DateTime date, TransactionType type)
        {
            _amount = amount;
            _date = date;
            _type = type;
        }

        public decimal CurrentBalance(decimal previousBalance)
        {
            if (_type == TransactionType.Credit)
            {
                return previousBalance + _amount;
            }

            return previousBalance - _amount;
        }

        protected bool Equals(Transaction other)
        {
            return _amount == other._amount && _date.Equals(other._date) && _type == other._type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _amount.GetHashCode();
                hashCode = (hashCode * 397) ^ _date.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) _type;
                return hashCode;
            }
        }

        public string Format(decimal balance)
        {
            if (_type == TransactionType.Credit)
                return $"{_date:dd/MM/yyyy} || {_amount:N} ||          || {balance:N}";

            return $"{_date:dd/MM/yyyy} ||          || {_amount:N} || {balance:N}";
        }
    }
}