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
                new BuyTradeTransaction {
                    Amount = 262.1512756M,
                    ExchangeId = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    ExchangeTransactionId = 2035424,
                    Fee =  0.00001286M,
                    Market = "FLIK/BTC",
                    NetTotal = 0.00858783M,
                    Price = 0.00003271M,
                    Timestamp = DateTime.Parse("10/20/2017 2:54:21"),
                    Total = 0.00857497M
                },
                new SellTradeTransaction {
                    Amount = 226.28148727M,
                    ExchangeId = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    ExchangeTransactionId = 2031982,
                    Fee =  0.0000124M,
                    Market = "FLIK/BTC",
                    NetTotal = 0.00825593M,
                    Price = 0.00003654M,
                    Timestamp = DateTime.Parse("10/20/2017 0:03:12"),
                    Total = 0.00826833M
                }
            };
        }

        public BaseTradeTransaction Find(Guid id)
        {
            if(id == null)
            {
                return null;
            }

            return _trades.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<BaseTradeTransaction> FindAll()
        {
            return _trades;
        }
    }
}
