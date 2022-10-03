using System.Collections.Generic;
using System.Threading.Tasks;
using NetPresentValue.Service.Models;
using NetPresentValue.UI.Controllers.Model;

namespace NetPresentValue.UI
{
    public interface ICalculatorService
    {
        Task<IEnumerable<dynamic>> GetCalculatedResult(ApiParamsModel apiParamsModel);
    }
}
