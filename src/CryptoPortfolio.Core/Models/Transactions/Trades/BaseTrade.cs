using CryptoPortfolio.Core.Interfaces;
using System;

namespace CryptoPortfolio.Core.Models.Transactions.Trades
{
    public class BaseTrade : ITrade
    {
        public DateTime Timestamp { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal NetTotal { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public Guid Id { get; }
        public ICurrency BaseCurrency { get; set; }
        public ICurrency CounterCurrency { get; set; }
        public IExchange Exchange { get; set; }
        public string ExchangeTransactionId { get; set; }
    }
}
