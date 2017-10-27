using CryptoPortfolio.Core.Extensions;
using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Core.Models;
using CryptoPortfolio.Core.Models.Exchanges;
using CryptoPortfolio.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CryptoPortfolio.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IExchangeRepository, MockExchangeRepository>()
                .AddSingleton<ITradeService<CryptopiaExchange>, CryptopiaTradeService>()
                .AddSingleton<ITradeService<BittrexExchange>, BittrexTradeService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Getting trades...\n\n");


            var trades = new List<ITrade>();
            trades.AddRange(serviceProvider.GetService<ITradeService<BittrexExchange>>().FindAll());
            trades.AddRange(serviceProvider.GetService<ITradeService<CryptopiaExchange>>().FindAll());

            WriteLine("\n\n\n\n");

            foreach (var group in trades.OrderBy(t => t.BaseCurrency.Code.ToString()).ThenBy(t => t.CounterCurrency.Code.ToString()).GroupBy(t => t.CounterCurrency)) {
                WriteLine($"{String.Concat(group.First().BaseCurrency.Code.ToString(), "/", group.Key.Code.ToString()).PadRight(10)} | Trades: {group.Count().ToString().PadRight(3)} | WA: {group.WeightedAverage(t => (t is BuyTrade ? t.Price : -t.Price), t => t.Amount)}");
            }

            logger.LogDebug("\n\n\n\nPress any key to exit...");
            ReadKey();
        }

        private static IEnumerable<ITrade> GetBittrexTrades(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ITradeService<BittrexExchange>>().FindAll();

        }

        private static IEnumerable<ITrade> GetCryptopiaTrades(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ITradeService<CryptopiaExchange>>().FindAll();
        }
    }
}
