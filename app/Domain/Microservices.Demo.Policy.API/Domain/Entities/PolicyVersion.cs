using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    public partial class PolicyVersion
    {
        public static PolicyVersion FromOffer(
           Policy policy,
           int version,
           PolicyHolder policyHolder,
           Offer offer)
        {
            return new PolicyVersion(policy, version, policyHolder, offer);
        }
        public virtual bool IsEffectiveOn(DateTime theDate)
        {
            return VersionValidityPeriodPolicyValidityPeriod.Contains(theDate);
        }
        public virtual PolicyVersion EndOn(DateTime endDate)
        {
            var endedCovers = this.PolicyCovers.Select(c => c.EndOn(endDate)).ToList();

            var termVersion = new PolicyVersion
            {
                Policy = this.Policy,
                VersionNumber = this.Policy.NextVersionNumber(),
                PolicyHolder = new PolicyHolder(PolicyHolder.FirstName, PolicyHolder.LastName, PolicyHolder.Pesel, PolicyHolder.Address),
                CoverPeriodPolicyValidityPeriod = CoverPeriodPolicyValidityPeriod.EndOn(endDate),
                VersionValidityPeriodPolicyValidityPeriod = PolicyValidityPeriod.Between(endDate.AddDays(1), VersionValidityPeriodPolicyValidityPeriod.PolicyTo),
                PolicyCovers = endedCovers,
                TotalPremiumAmount = endedCovers.Sum(c => c.Premium)
            };
            return termVersion;
        }
        private PolicyVersion(
            Policy policy,
            int version,
            PolicyHolder policyHolder,
            Offer offer)
        {
            Policy = policy;
            VersionNumber = version;
            PolicyHolder = policyHolder;
            CoverPeriodPolicyValidityPeriod = offer.PolicyValidityPeriod.Clone();
            VersionValidityPeriodPolicyValidityPeriod = offer.PolicyValidityPeriod.Clone();
            PolicyCovers = offer.OfferCovers.Select(c => new PolicyCover(c, offer.PolicyValidityPeriod.Clone())).ToList();
            TotalPremiumAmount = PolicyCovers.Sum(c => c.Premium);
        }
    }
}
