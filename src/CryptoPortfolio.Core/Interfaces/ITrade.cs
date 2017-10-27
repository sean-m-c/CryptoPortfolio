using CryptoPortfolio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Interfaces
{
    public interface ITrade
    {
         ICurrency BaseCurrency { get; set; }
         ICurrency CounterCurrency { get; set; }
         DateTime Timestamp { get; set; }
         decimal Amount { get; set; }
         decimal Fee { get; set; }
         decimal NetTotal { get; set; }
         decimal Price { get; set; }
         decimal Total { get; set; }
         IExchange Exchange { get; set; }
         Guid Id { get; }
         string ExchangeTransactionId { get; set; }
    }
}
