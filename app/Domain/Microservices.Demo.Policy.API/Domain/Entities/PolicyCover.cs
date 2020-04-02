using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    public partial class PolicyCover
    {
        protected PolicyCover() { }
        public PolicyCover(OfferCover offerCover, PolicyValidityPeriod coverPeriod)
        {
            Code = offerCover.Code;
            Premium = offerCover.Price;
            PolicyValidityPeriod = coverPeriod;
        }
        public PolicyCover EndOn(DateTime endDate)
        {
            var originalDaysCovered = PolicyValidityPeriod.Days;
            var daysNotUsed = originalDaysCovered - PolicyValidityPeriod.EndOn(endDate).Days;
            var premium = decimal.Round
            (
                this.Premium - (this.Premium * decimal.Divide(daysNotUsed, originalDaysCovered))
                , 2
            );

            return new PolicyCover
            {
                Code = this.Code,
                Premium = premium,
                PolicyValidityPeriod = this.PolicyValidityPeriod.EndOn(endDate)
            };
        }
    }
}
