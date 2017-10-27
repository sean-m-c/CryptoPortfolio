using CryptoPortfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoPortfolio.Core.Models;
using CryptoPortfolio.Core.Models.Exchanges;

namespace CryptoPortfolio.Infrastructure
{
    public class MockCryptopiaTradeRepository : ITradeService<CryptopiaExchange>
    {
        private readonly IEnumerable<ITrade> _trades;
        private readonly IExchangeRepository _exchangeRepository;

        public MockCryptopiaTradeRepository(IExchangeRepository exchangeRepository)
        {
            var exchange = _exchangeRepository.Find("cryptopia");

            _trades = new List<ITrade>
            {
                new BuyTrade {
                    Amount = 262.1512756M,
                    BaseCurrency = new Currency("BTC"),
                    CounterCurrency = new Currency("FLIK"),
                    Exchange = exchange,
                    ExchangeTransactionId = "2035424",
                    Fee =  0.00001286M,
                    NetTotal = 0.00858783M,
                    Price = 0.00003271M,
                    Timestamp = DateTime.Parse("10/20/2017 2:54:21"),
                    Total = 0.00857497M
                },
                new SellTrade {
                    Amount = 226.28148727M,
                    BaseCurrency = new Currency("BTC"),
                    CounterCurrency = new Currency("FLIK"),
                    Exchange = exchange,
                    ExchangeTransactionId = "2031982",
                    Fee =  0.0000124M,
                    NetTotal = 0.00825593M,
                    Price = 0.00003654M,
                    Timestamp = DateTime.Parse("10/20/2017 0:03:12"),
                    Total = 0.00826833M
                }
            };
        }

        public ITrade Find(Guid id)
        {
            if(id == null)
            {
                return null;
            }

            return _trades.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<ITrade> FindAll()
        {
            return _trades;
        }
    }
}
