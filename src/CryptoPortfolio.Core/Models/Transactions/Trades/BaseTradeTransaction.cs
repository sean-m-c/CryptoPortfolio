using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Models
{
    public class BaseTradeTransaction : BaseTransaction
    {
        public string Market { get; set; }
    }
}
