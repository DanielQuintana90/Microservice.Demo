using MediatR;
using Microservices.Demo.Report.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using Microservices.Demo.Report.API.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.CQRS.Queries.FindAllPolicies
{
    public class FindAllPoliciesHandler : IRequestHandler<FindAllPoliciesQuery, IEnumerable<PolicyDto>>
    {
        private readonly IReportRepository _reportRepository;
        public FindAllPoliciesHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository ?? throw new ArgumentNullException(nameof(reportRepository));
        }

        public async Task<IEnumerable<PolicyDto>> Handle(FindAllPoliciesQuery request, CancellationToken cancellationToken)
        {
            var result = await _reportRepository.GetPolicies();

            return result.Select(p => new PolicyDto
            {
                PolicyId = p.PolicyId,
                Number = p.Number,
                ProductCode = p.ProductCode,
                AgentLogin = p.AgentLogin,
                PolicyStatusId = p.PolicyStatusId,
                CreationDate = p.CreationDate
            }).ToList();
        }
    }
}
