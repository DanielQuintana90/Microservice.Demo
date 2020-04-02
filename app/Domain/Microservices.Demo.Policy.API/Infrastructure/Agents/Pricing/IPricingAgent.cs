using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing
{
    public interface IPricingAgent<TPrice, TAnswer>
    {
        Task<TPrice> CalculatePrice(PricingParams<TAnswer> pricingParams);
    }

    public class PricingParams<TAnswer>
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<TAnswer> Answers { get; set; }
    }
}
