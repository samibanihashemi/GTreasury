using System.Collections.Generic;

namespace NetPresentValue.UI.Controllers.Model
{
    public class ApiParamsModel
    {
        public string cashValues { get; set; }
        public decimal lowBoundDiscRate { get; set; }
        public decimal upBoundDiscRate { get; set; }
        public decimal discRateIncrement { get; set; }
    }
}
