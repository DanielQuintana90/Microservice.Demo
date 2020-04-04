using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    public class Price
    {
        private Dictionary<string, decimal> coverPrices;

        public IReadOnlyDictionary<string, decimal> CoverPrices => new ReadOnlyDictionary<string, decimal>(coverPrices);

        public Price(Dictionary<string, decimal> coverPrices)
        {
            this.coverPrices = coverPrices;
        }
    }
}
