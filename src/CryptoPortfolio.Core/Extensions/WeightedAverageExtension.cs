using CryptoPortfolio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoPortfolio.Core.Extensions
{
    public static class WeightedAverageExtension
    {
        public static decimal WeightedAverage<T>(this IEnumerable<T> items, Func<T, decimal> value, Func<T, decimal> weight)
        {
            decimal weightedValueSum = items.Sum(x => value(x) * weight(x));
            decimal weightSum = items.Sum(x => weight(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            else
                throw new DivideByZeroException("Your message here");
        }
    }
}
