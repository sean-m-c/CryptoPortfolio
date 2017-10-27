using CryptoPortfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Mvc.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<ITrade> Trades { get; set; }
    }
}
