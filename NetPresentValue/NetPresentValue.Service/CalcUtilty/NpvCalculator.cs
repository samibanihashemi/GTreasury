using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using NetPresentValue.Service.Models;
using System.Linq;
using Serilog;

namespace NetPresentValue.Service.CalcUtilty
{
    public class NpvCalculator : ICalculator
    {
        /// <summary>
        /// Calculate Net Present Value
        /// </summary>
        /// <returns>IEnumerable<NpvViewModel></returns>

        public async Task<IEnumerable<dynamic>> Calculate(NpvParamsModel npvParamsModel)
        {
            var result = await Task.Run(() =>
            {
                var year = 0;
                var dynList = npvParamsModel.cashValues
                       .Select(s => CalculatePerYear(s, npvParamsModel.lowBoundDiscRate, npvParamsModel.upBoundDiscRate, npvParamsModel.discRateIncrement, ++year))
                       .ToList();
                return dynList;
            });
            return result;
        }

        public IDictionary<string, Object> CalculatePerYear(
            decimal cashValue, decimal lowBoundDiscRate, decimal upBoundDiscRate, decimal discRateIncrement, int year)
        {
            var yearData = new ExpandoObject() as IDictionary<string, Object>;
            yearData.Add("id", year);
            yearData.Add("cashvalue", cashValue);

            var discRate = lowBoundDiscRate;
            while (discRate <= upBoundDiscRate)
            {
                var denominator = 1 + (discRate / 100);
                var npv = cashValue / CalculationHelper.Pow(denominator, year);
                yearData.Add($"{discRate.ToString()}%", Math.Round(npv,2));
                discRate += discRateIncrement;
            }
            return yearData;
        }
    }
}
