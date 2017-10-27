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

namespace CryptoPortfolio.Infrastructure
{
    public class BittrexTradeService : BaseTradeService<BittrexExchange, BittrexTradeDto>
    {
        const string _cultureCode = "en-us";
        const string _delimiter = "-";
        const string _fileName = @"C:\Users\seac\Desktop\fullOrders.xlsx";
        const string _strBuyIndicator = "LIMIT_BUY";
        const string _strLimitIndicator = "LIMIT_SELL";

        private readonly IExchange _exchange;

        public BittrexTradeService(IExchangeRepository exchangeRepository, ILoggerFactory loggerFactory) : 
            base(_fileName, exchangeRepository, loggerFactory, new CultureInfo(_cultureCode).DateTimeFormat, _delimiter, _strBuyIndicator, _strLimitIndicator)
        {
        }

        protected override BuyTrade MapBuyTrade(BittrexTradeDto trade) 
        {
            return new BuyTrade
            {
                Amount = trade.Quantity,
                BaseCurrency = ParseBaseCurrency(trade.Exchange),
                CounterCurrency = ParseCounterCurrency(trade.Exchange),
                Exchange = _exchange,
                ExchangeTransactionId = trade.OrderUuid,
                Fee = trade.Commission,
                NetTotal = trade.Limit + trade.Commission,
                Price = trade.Price,
                Timestamp = trade.Closed,
                Total = trade.Limit
            };
        }

        protected override SellTrade MapSellTrade(BittrexTradeDto trade)
        {
            return new SellTrade
            {
                Amount = trade.Quantity,
                BaseCurrency = ParseBaseCurrency(trade.Exchange),
                CounterCurrency = ParseCounterCurrency(trade.Exchange),
                Exchange = _exchange,
                ExchangeTransactionId = trade.OrderUuid,
                Fee = trade.Commission,
                NetTotal = trade.Limit + trade.Commission,
                Price = trade.Price,
                Timestamp = trade.Closed,
                Total = trade.Limit
            };
        }
    }
}
