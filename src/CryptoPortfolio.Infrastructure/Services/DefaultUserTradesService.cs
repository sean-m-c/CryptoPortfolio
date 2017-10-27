using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Core.Models.DTO;
using CryptoPortfolio.Core.Models.Exchanges;
using System.Collections.Generic;
using System.Linq;

namespace CryptoPortfolio.Infrastructure.Services
{
    public class DefaultUserTradesService : IUserTradesService
    {
        private readonly ITradeService<CryptopiaExchange> _cryptopiaTradeService;
        private readonly ITradeService<BittrexExchange> _bittrexTradeService;

        public DefaultUserTradesService(
            ITradeService<CryptopiaExchange> cryptopiaTradeService, 
            ITradeService<BittrexExchange> bittrexTradeService
            )
        {
            _cryptopiaTradeService = cryptopiaTradeService;
            _bittrexTradeService = bittrexTradeService;
        }


        public IEnumerable<ITrade> FindAll()
        {
            return _cryptopiaTradeService.FindAll().Concat(_bittrexTradeService.FindAll());
        }
    }
}
