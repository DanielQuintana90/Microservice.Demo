using Microservices.Demo.Policy.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enum=Microservices.Demo.Policy.API.Domain.Enum;

namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    public partial class Offer
    {
        public Offer(
            string productCode,
            DateTime policyFrom,
            DateTime policyTo,
            PolicyHolder policyHolder,
            Price price,
            string agentLogin)
        {
            Number = Guid.NewGuid().ToString();
            ProductCode = productCode;
            PolicyValidityPeriod = PolicyValidityPeriod.Between(policyFrom, policyTo);
            PolicyHolder = policyHolder;
            OfferCovers = price.CoverPrices.Select(c => new OfferCover(c.Key, c.Value)).ToList();
            OfferStatusId = (int)Enum.OfferStatus.New;
            CreationDate = SysTime.CurrentTime;
            TotalPrice = price.CoverPrices.Sum(c => c.Value);
            AgentLogin = agentLogin;

        }
    }
}
