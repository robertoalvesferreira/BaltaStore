using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);

        void Save(Customer customer);

        IEnumerable<ListCustomerQueryResult> Get();

        GetCustomerQueryResult GetById(Guid Id);

        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
    }
}
