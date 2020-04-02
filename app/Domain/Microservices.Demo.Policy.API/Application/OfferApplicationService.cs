using MediatR;
using Microservices.Demo.Policy.API.CQRS.Commands.CreateOffer;
using Microservices.Demo.Policy.API.CQRS.Commands.CreateOfferByAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.String;

namespace Microservices.Demo.Policy.API.Application
{    
    public class OfferApplicationService
    {
        private readonly IMediator _mediator;
        public OfferApplicationService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<CreateOfferResult> CreateOfferAsync(CreateOfferCommand command, string agentLogin)
        {
            var result = IsNullOrWhiteSpace(agentLogin) ? await _mediator.Send(command) : await _mediator.Send(new CreateOfferByAgentCommand(agentLogin, command));
            var offer = await _mediator.Send(command);
            return offer;
        }        
    }
}
