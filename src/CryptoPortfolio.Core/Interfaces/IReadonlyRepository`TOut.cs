using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolio.Core.Interfaces
{
    public interface IReadonlyRepository<TOut>
    {
        TOut Find(Guid id);
        IEnumerable<TOut> FindAll();
    }
}
