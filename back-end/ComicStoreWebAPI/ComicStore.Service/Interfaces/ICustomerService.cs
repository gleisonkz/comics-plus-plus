using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Classes;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ComicStore.Service.Interfaces
{
    public interface ICustomerService : IServiceFacadeBase
    {
        Customer CreateCustomer(string userID);

    }
}
