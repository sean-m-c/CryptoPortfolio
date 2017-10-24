using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Core.Models;

namespace CryptoPortfolio.Infrastructure
{
    public class MockExchangeRepository : IExchangeRepository
    {
        private readonly IEnumerable<Exchange> _exchanges;

        public MockExchangeRepository()
        {
            _exchanges = new List<Exchange> {
                new Exchange { Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Bittrex", Uri = new Uri("http://bittrex.com/") },
                new Exchange { Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), Name = "Cryptopia", Uri = new Uri("https://yobit.net/") }
            };
        }

        public Exchange Find(Guid exchangeId)
        {
            return _exchanges.SingleOrDefault(e => e.Id == exchangeId);
        }

        public Exchange Find(string exchangeName)
        {
            if(string.IsNullOrWhiteSpace(exchangeName))
            {
                return null;
            }

            return _exchanges.SingleOrDefault(e => e.Name.ToLowerInvariant() == exchangeName.ToLowerInvariant());
        }

        public IEnumerable<Exchange> FindAll()
        {
            return _exchanges;
        }
    }
}
