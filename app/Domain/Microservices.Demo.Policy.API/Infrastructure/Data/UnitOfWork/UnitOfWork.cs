using Microservices.Demo.Policy.API.Infrastructure.Data.Context;
using Microservices.Demo.Policy.API.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PolicyDbContext _policyDbContext;
        private readonly IDbContextTransaction tx;
        private readonly OfferRepository _offerRepository;
        private readonly PolicyRepository _policyRepository;

        public IOfferRepository Offers => _offerRepository;

        public IPolicyRepository Policies => _policyRepository;


        public UnitOfWork(PolicyDbContext policyDbContext)
        {
            _policyDbContext = policyDbContext;
            tx = _policyDbContext.Database.BeginTransaction();
            _offerRepository = new OfferRepository(policyDbContext);
            _policyRepository = new PolicyRepository(policyDbContext);
        }

        public async Task CommitChanges()
        {
            _policyDbContext.SaveChanges();
            await tx.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                tx?.Dispose();
            }

        }
    }
}
