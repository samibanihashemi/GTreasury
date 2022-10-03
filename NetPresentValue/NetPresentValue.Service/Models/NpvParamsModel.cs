using System.Collections.Generic;

namespace NetPresentValue.Service.Models
{
    public class NpvParamsModel
    {
        public IEnumerable<decimal> cashValues { get; set; }
        public decimal lowBoundDiscRate { get; set; }
        public decimal upBoundDiscRate { get; set; }
        public decimal discRateIncrement { get; set; }
    }
}
