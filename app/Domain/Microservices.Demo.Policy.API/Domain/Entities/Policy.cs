namespace Microservices.Demo.Policy.API.Infrastructure.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Enum = Microservices.Demo.Policy.API.Domain.Enum;
    public partial class Policy
    {
        public static Policy FromOffer(PolicyHolder policyHolder, Offer offer)
        {
            return new Policy(policyHolder, offer);
        }
        protected Policy(PolicyHolder policyHolder, Offer offer)
        {
            Number = Guid.NewGuid().ToString();
            ProductCode = offer.ProductCode;
            PolicyStatusId = (int)Enum.PolicyStatus.Active;
            CreationDate = SysTime.CurrentTime;
            AgentLogin = offer.AgentLogin;
            PolicyVersions.Add(PolicyVersion.FromOffer(this, 1, policyHolder, offer));
        }
        public virtual int NextVersionNumber() => PolicyVersions.Count == 0 ? 1 : PolicyVersions.LastVersion().VersionNumber + 1;
    }
}
