namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Enum = Microservices.Demo.Policy.API.Domain.Enum;
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
