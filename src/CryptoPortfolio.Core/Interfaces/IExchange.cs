using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Interfaces
{
    public interface IExchange
    {
         Guid Id { get; set; }
         string Name { get; set; }
         Uri Uri { get; set; }
    }
}
