using CryptoPortfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Models.Exchanges
{
    public abstract class BaseExchange : IExchange
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Uri Uri { get; set; }
    }
}
