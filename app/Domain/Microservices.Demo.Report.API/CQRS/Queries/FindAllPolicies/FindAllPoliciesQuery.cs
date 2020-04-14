using MediatR;
using Microservices.Demo.Report.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using System.Collections.Generic;

namespace Microservices.Demo.Report.API.CQRS.Queries.FindAllPolicies
{
    public class FindAllPoliciesQuery : IRequest<IEnumerable<PolicyDto>>
    {
    }
}
