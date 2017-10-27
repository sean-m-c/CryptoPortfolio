using CryptoPortfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Models
{
    public class CurrencyCode : IEquatable<CurrencyCode>, ICurrencyCode
    {
        public string Value { get; }

        public CurrencyCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException("code");

            code = code.Trim();
            Value = code.ToUpper();
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(CurrencyCode other)
        {
            if (other == null) return false;

            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals(obj as CurrencyCode);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                var myStrHashCode = !string.IsNullOrEmpty(Value) ? Value.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ myStrHashCode;
                hashCode = (hashCode * 397) ^ DateTime.Now.GetHashCode();
                return hashCode;
            }
        }

        public static implicit operator string(CurrencyCode currencyCode)
        {
            return currencyCode.ToString();
        }
    }
}
