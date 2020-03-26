using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing.Entities
{
    public class Price
    {
        private Dictionary<string, decimal> coverPrices;
        public Price(Dictionary<string, decimal> coverPrices)
        {
            this.coverPrices = coverPrices;
        }
    }
}
