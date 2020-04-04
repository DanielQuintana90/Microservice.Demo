namespace Microservices.Demo.Policy.API.Domain
{
    using Microservices.Demo.Policy.API.Infrastructure.Data.Entities;
    using System;

    public class OfferDomainService
    {
        public static Offer CreateOfferForPrice(String productCode,
            DateTime policyFrom,
            DateTime policyTo,
            PolicyHolder policyHolder,
            Price price)
        {
            return new Offer
            (
                productCode,
                policyFrom,
                policyTo,   
                policyHolder,
                price,
                null
            );
        }

        public static Offer CreateOfferForPriceAndAgent(
           string productCode,
           DateTime policyFrom,
           DateTime policyTo,
           PolicyHolder policyHolder,
           Price price,
           string agent)
        {
            return new Offer
            (
                productCode,
                policyFrom,
                policyTo,
                policyHolder,
                price,
                agent
            );
        }
        public virtual Policy Buy(Offer offer, PolicyHolder customer)
        {
            if (IsExpired(offer,SysTime.CurrentTime))
                throw new ApplicationException($"Offer {offer.Number} has expired");

            if (offer.OfferStatusId != (int)Enum.OfferStatus.New)
                throw new ApplicationException($"Offer {offer.Number} is not in new status and cannot be bought");

            offer.OfferStatusId = (int)Enum.OfferStatus.Converted;

            return Policy.FromOffer(customer, offer);
        }
        public virtual bool IsExpired(Offer offer, DateTime theDate)
        {
            return offer.CreationDate.AddDays(30) < theDate;
        }
    }
}
