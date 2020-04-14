using MediatR;
using Microservices.Demo.Report.API.CQRS.Queries.FindAllPolicies;
using Microservices.Demo.Report.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Application
{
    public class PolicyApplicationService
    {
        private readonly IMediator _mediator;
        public PolicyApplicationService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<PolicyDto>> GetAllPolicies()
        {
            var policies = await _mediator.Send(new FindAllPoliciesQuery());

            return policies;
        }

    }
}
