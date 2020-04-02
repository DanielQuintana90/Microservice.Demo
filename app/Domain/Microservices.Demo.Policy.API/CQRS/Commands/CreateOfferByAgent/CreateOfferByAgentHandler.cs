using MediatR;
using Microservices.Demo.Policy.API.CQRS.Commands.CreateOffer;
using Microservices.Demo.Policy.API.Domain;
using Microservices.Demo.Policy.API.Domain.Entities;
using Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing;
using Microservices.Demo.Policy.API.Infrastructure.Data.Entities;
using Microservices.Demo.Policy.API.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.CQRS.Commands.CreateOfferByAgent
{
    public class CreateOfferByAgentHandler : IRequestHandler<CreateOfferByAgentCommand, CreateOfferResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPricingAgent<Price, Answer> _pricingAgent;

        public CreateOfferByAgentHandler(IUnitOfWork unitOfWork, IPricingAgent<Price, Answer> pricingAgent)
        {
            _unitOfWork = unitOfWork;
            _pricingAgent = pricingAgent;
        }

        public async Task<CreateOfferResult> Handle(CreateOfferByAgentCommand request, CancellationToken cancellationToken)
        {
            //calculate price
            var priceParams = ConstructPriceParams(request);
            var price = await _pricingAgent.CalculatePrice(priceParams);


            var offer = OfferDomainService.CreateOfferForPriceAndAgent(
                priceParams.ProductCode,
                priceParams.PolicyFrom,
                priceParams.PolicyTo,
                null,
                price,
                request.AgentLogin
            );

            //create and save offer
            await _unitOfWork.Offers.Add(offer);
            await _unitOfWork.CommitChanges();

            //return result
            return ConstructResult(offer);
        }

        private CreateOfferResult ConstructResult(Offer offer)
        {
            return new CreateOfferResult
            {
                OfferNumber = offer.Number,
                TotalPrice = offer.TotalPrice,
                CoversPrices = offer.OfferCovers.ToDictionary(c => c.Code, c => c.Price)
            };
        }

        private PricingParams<Answer> ConstructPriceParams(CreateOfferCommand request)
        {
            return new PricingParams<Answer>
            {
                ProductCode = request.ProductCode,
                PolicyFrom = request.PolicyFrom,
                PolicyTo = request.PolicyTo,
                SelectedCovers = request.SelectedCovers,
                Answers = request.Answers.Select(a => Answer.Create(a.QuestionType, a.QuestionCode, a.GetAnswer())).ToList()
            };
        }

    }
}
