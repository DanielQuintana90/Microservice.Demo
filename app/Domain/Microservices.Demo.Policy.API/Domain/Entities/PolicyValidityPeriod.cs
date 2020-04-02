using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    public partial class PolicyValidityPeriod: ICloneable
    {
        public PolicyValidityPeriod(DateTime policyFrom, DateTime policyTo)
        {
            PolicyFrom = policyFrom;
            PolicyTo = policyTo;
        }
        public static PolicyValidityPeriod Between(DateTime policyFrom, DateTime policyTo)
           => new PolicyValidityPeriod(policyFrom, policyTo);

        public PolicyValidityPeriod Clone()
        {
            return new PolicyValidityPeriod(PolicyFrom, PolicyTo);
        }
        public bool Contains(DateTime theDate)
        {
            if (theDate > PolicyTo)
                return false;

            if (theDate < PolicyFrom)
                return false;

            return true;
        }

        public PolicyValidityPeriod EndOn(DateTime endDate)
        {
            return new PolicyValidityPeriod(PolicyFrom, endDate);
        }

        public int Days => PolicyTo.Subtract(PolicyFrom).Days;

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
