using CryptoPortfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoPortfolio.Core.Models;

namespace CryptoPortfolio.Infrastructure
{
    public class MockTradeTransactionRepository : ITradeTransactionRepository
    {
        private readonly IEnumerable<BaseTradeTransaction> _trades;

        public MockTradeTransactionRepository()
        {
            _trades = new List<BaseTradeTransaction>
            {
                new BaseTradeTransaction {
                    Amount = 262.1512756, ExchangeId = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), ExchangeTransactionId = "2035424", Fee =  2035424, Market = "FLIK/BTC", NetTotal = 0.00858783, Price = 0.00003271, Timestamp = DateTime.Parse("10/20/2017 2:54:21"), Total = 0.00857497 }
            }
        }

        public BaseTradeTransaction Find(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseTradeTransaction> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
