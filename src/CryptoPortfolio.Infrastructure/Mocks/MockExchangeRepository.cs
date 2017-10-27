using System;
using System.Collections.Generic;
using System.Linq;
using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Core.Models.Exchanges;

namespace CryptoPortfolio.Infrastructure
{
    public class MockExchangeRepository : IExchangeRepository
    {
        private readonly IEnumerable<IExchange> _exchanges;
        private const string _exchangeNameSuffix = "Exchange";

        public MockExchangeRepository()
        {
            _exchanges = new List<IExchange> {
                new CryptopiaExchange { Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Bittrex", Uri = new Uri("http://bittrex.com/") },
                new BittrexExchange { Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), Name = "Cryptopia", Uri = new Uri("https://bittrex.com/") }
            };
        }

        public IExchange Find(Guid exchangeId)
        {
            if (exchangeId == null) return null;

            return _exchanges.SingleOrDefault(e => e.Id == exchangeId);
        }

        public IExchange Find<TExchangeType>(TExchangeType exchangeType)
        {
            if (exchangeType == null) return null;

            return FindByName(exchangeType.ToString().Split(Convert.ToChar(".")).Last().Replace(_exchangeNameSuffix, string.Empty));
        }

        public IExchange Find(string exchangeName)
        {
            if(string.IsNullOrWhiteSpace(exchangeName)) return null;

            return FindByName(exchangeName);
        }

        public IEnumerable<IExchange> FindAll()
        {
            return _exchanges;
        }

        private IExchange FindByName(string exchangeName)
        {
            return _exchanges.SingleOrDefault(e => e.Name.ToLowerInvariant() == exchangeName.ToLowerInvariant());
        }
    }
}
