using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Interfaces
{
    public interface IUserTradesService
    {
        IEnumerable<ITrade> FindAll();
    }
}
