using CryptoPortfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Models
{
    public class Currency : IEquatable<ICurrency>, ICurrency
    {
        public ICurrencyCode Code { get; }
        public string Name { get; }

        public Currency(string code, string name)
        {
            if (code == null) throw new ArgumentNullException("code");

            Code = new CurrencyCode(code);
            Name = name ?? string.Empty;
        }

        public Currency(ICurrencyCode code, string name)
        {
            if (code == null) throw new ArgumentNullException("code");

            Code = code;
            Name = name ?? string.Empty;
        }

        public Currency(ICurrencyCode code)
        {
            if (code == null) throw new ArgumentNullException("code");

            Code = code;
            Name = string.Empty;
        }

        public Currency(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException("code");

            Code = new CurrencyCode(code);
            Name = string.Empty;
        }

        public override string ToString()
        {
            return Code.ToString();
        }

        public bool Equals(ICurrency other)
        {
            if (other == null) return false;

            return Code.Equals(other.Code) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals(obj as Currency);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                var myStrHashCode = !string.IsNullOrEmpty(Name) ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ myStrHashCode;
                hashCode = (hashCode * 397) ^ Code.GetHashCode();
                hashCode = (hashCode * 397) ^ DateTime.Now.GetHashCode();

                return hashCode;
            }
        }

        public static implicit operator string(Currency currency)
        {
            return currency.Code.ToString();
        }
    }
}
