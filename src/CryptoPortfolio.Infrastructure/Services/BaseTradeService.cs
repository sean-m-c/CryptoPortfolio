using CryptoPortfolio.Core.Extensions;
using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Core.Models;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CryptoPortfolio.Infrastructure
{
    public abstract class BaseTradeService<TExchange, TTradeDto> : ITradeService<TExchange> 
        where TTradeDto : ITradeDto, new()
        where TExchange : IExchange
    {
        const int worksheetIndex = 1;
        readonly string _filePath;
        readonly IExchange _exchange;
        readonly ILogger _logger;
        readonly DateTimeFormatInfo _dateTimeFormatInfo;
        readonly Char _currencyDelimiter;
        readonly string _buyTradeIndicator;
        readonly string _sellTradeIndicator;

        public BaseTradeService(
            string fileName, 
            IExchangeRepository exchangeRepository, 
            ILoggerFactory loggerFactory, 
            DateTimeFormatInfo dateTimeFormatInfo,
            string currencyDelimiter,
            string buyTradeIndicator,
            string sellTradeIndicator
            )
        {
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger<BaseTradeService<TExchange, TTradeDto>>();
          
            if (exchangeRepository == null) throw new ArgumentNullException(nameof(exchangeRepository));
            Type exchangeType = typeof(TExchange);

            _exchange = exchangeRepository.Find(exchangeType);
            if (_exchange == null) throw new InvalidOperationException(string.Format("Could not find exchange for the given exchange type: {0}", exchangeType.ToString()));

            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));
            _filePath =  Path.Combine(Directory.GetCurrentDirectory(), "..\\", "..\\", "Assets", "TradeHistory", string.Concat(fileName, ".xlsx")); ;
            if (!File.Exists(_filePath)) throw new FileNotFoundException("Could not locate the excel file with the trade information.", _filePath);

            _dateTimeFormatInfo = dateTimeFormatInfo;
            if (_dateTimeFormatInfo == null) throw new ArgumentNullException(nameof(dateTimeFormatInfo));

            if (currencyDelimiter == null) throw new ArgumentNullException(nameof(dateTimeFormatInfo));
            _currencyDelimiter = Convert.ToChar(currencyDelimiter);

            if (buyTradeIndicator == null) throw new ArgumentNullException(nameof(buyTradeIndicator));
            _buyTradeIndicator = buyTradeIndicator.ToLower();

            if (sellTradeIndicator == null) throw new ArgumentNullException(nameof(sellTradeIndicator));
            _sellTradeIndicator = sellTradeIndicator.ToLower();
        }


        public ITrade Find(Guid id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ITrade> FindAll()
        {

            _logger.LogInformation("Getting list of trades for exchange {exchangeName}.", _exchange.Name);

            using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
            {
                ExcelPackage excel = new ExcelPackage(fileStream);
                var workSheet = excel.Workbook.Worksheets[worksheetIndex];
                var tradeDTOs = workSheet.ConvertSheetToObjects<TTradeDto>(_dateTimeFormatInfo);

                var mappedTrades = new List<ITrade>();
                foreach (var trade in tradeDTOs)
                {
                    _logger.LogTrace("Mapping trade DTO {trade}.", trade);

                    ITrade mappedTrade = null;

                    if (IsBuyTrade(trade))
                    {
                        mappedTrade = MapBuyTrade(trade);

                    } else if (IsSellTrade(trade))
                    {
                        mappedTrade = MapSellTrade(trade);
                    }

                    if (mappedTrade != null)
                    {
                        mappedTrade.Exchange = _exchange;
                        mappedTrades.Add(mappedTrade);
                    }
                }

                return mappedTrades;
            }
        }

        protected bool IsBuyTrade(TTradeDto trade)
        {
            return trade.Type.ToLower() == _buyTradeIndicator;
        }

        protected bool IsSellTrade(TTradeDto trade)
        {
            return trade.Type.ToLower() == _sellTradeIndicator;
        }

        protected Currency ParseBaseCurrency(string market) {
            return new Currency(market.Split(_currencyDelimiter).First());
        }

        protected  Currency ParseCounterCurrency(string market)
        {
            return new Currency(market.Split(_currencyDelimiter).Last());
        }

        protected abstract BuyTrade MapBuyTrade(TTradeDto trade);

        protected abstract SellTrade MapSellTrade(TTradeDto trade);
    }
}
