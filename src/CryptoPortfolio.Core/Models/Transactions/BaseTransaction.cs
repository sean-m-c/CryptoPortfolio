using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Models
{
    public abstract class BaseTransaction
    {
        public Currency BaseCurrency { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal NetTotal { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public Guid ExchangeId { get; set; }
        public Guid Id { get; }
        public int? ExchangeTransactionId { get; set; }

        public BaseTransaction()
        {
            Id = Guid.NewGuid();
        }
    }
}
