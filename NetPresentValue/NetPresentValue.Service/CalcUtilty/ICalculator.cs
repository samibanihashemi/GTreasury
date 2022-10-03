using NetPresentValue.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetPresentValue.Service.CalcUtilty
{
    public interface ICalculator
    {
        Task<IEnumerable<dynamic>> Calculate(NpvParamsModel npvParamsModel);
    }
}
