using CryptoPortfolio.Core.Extensions;
using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Core.Models;
using CryptoPortfolio.Core.Models.DTO;
using CryptoPortfolio.Core.Models.Exchanges;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.PlatformAbstractions;

namespace CryptoPortfolio.Infrastructure
{
    public class CryptopiaTradeService : BaseTradeService<CryptopiaExchange, CryptopiaTradeDto>
    {
        const string _fileName = "Trade_History";
        const string _cultureCode = "en-gb";
        const string _delimiter = "/";
        const string _strBuyIndicator = "Buy";
        const string _strLimitIndicator = "Sell";

        public CryptopiaTradeService(IExchangeRepository exchangeRepository, ILoggerFactory loggerFactory) : 
            base(_fileName, exchangeRepository, loggerFactory, new CultureInfo(_cultureCode).DateTimeFormat, _delimiter, _strBuyIndicator, _strLimitIndicator)
        {
        }

        protected override BuyTrade MapBuyTrade(CryptopiaTradeDto trade) 
        {
            return new BuyTrade
            {
                Amount = trade.Amount,
                BaseCurrency = ParseBaseCurrency(trade.Market),
                CounterCurrency = ParseCounterCurrency(trade.Market),
                ExchangeTransactionId = trade.Id.ToString(),
                Fee = trade.Fee,
                NetTotal = trade.Total + trade.Fee,
                Price = trade.Rate,
                Timestamp = trade.Timestamp,
                Total = trade.Total
            };
        }

        protected override SellTrade MapSellTrade(CryptopiaTradeDto trade)
        {
            return new SellTrade
            {
                Amount = trade.Amount,
                BaseCurrency = ParseBaseCurrency(trade.Market),
                CounterCurrency = ParseCounterCurrency(trade.Market),
                ExchangeTransactionId = trade.Id.ToString(),
                Fee = trade.Fee,
                NetTotal = trade.Total + trade.Fee,
                Price = trade.Rate,
                Timestamp = trade.Timestamp,
                Total = trade.Total
            };
        }
    }
}
