using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Models
{
    public class Exchange
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Uri Uri { get; set; }
    }
}
