using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NetPresentValue.Service.CalcUtilty;
using NetPresentValue.Service.Models;
using NetPresentValue.UI.Controllers.Model;
using Serilog;

namespace NetPresentValue.UI
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculator _calculator;
        private readonly ILogger _logger;
        public CalculatorService(ICalculator calculator, ILogger logger)
        {
            _calculator = calculator;
            _logger = logger;
        }
        /// <summary>
        /// GetCalculatedResult
        /// </summary>
        /// <returns>Task<IEnumerable<NpvViewModel>></returns>

        public async Task<IEnumerable<dynamic>> GetCalculatedResult(ApiParamsModel apiParamsModel)
        {
            var result = await _calculator.Calculate(new NpvParamsModel()
            {
                cashValues = ConvertCashValues(apiParamsModel.cashValues),
                lowBoundDiscRate = apiParamsModel.lowBoundDiscRate,
                upBoundDiscRate = apiParamsModel.upBoundDiscRate,
                discRateIncrement = apiParamsModel.discRateIncrement
            });
            return result;
        }

        private IEnumerable<decimal> ConvertCashValues(string cashValues)
        {
            if (string.IsNullOrEmpty(cashValues))
            {
                throw new ArgumentNullException("Cannot get cash values");
            }
            var convertedValues = cashValues.Split(',');
            if (convertedValues == null || convertedValues.Length == 0)
            {
                throw new ArgumentNullException("Cannot get cash values");
            }
            var decimalCashValues = convertedValues
                .Select(s =>
                {
                    decimal output;
                    if (decimal.TryParse(s, out output))
                    {
                        return output;
                    }
                    return 0m;
                });
            return decimalCashValues;
        }
    }
}
