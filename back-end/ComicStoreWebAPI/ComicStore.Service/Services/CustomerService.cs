using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ComicStore.Service.Services
{
    public class CustomerService : ServiceFacadeBase, ICustomerService
    {
        private readonly IRepository<Customer> repoCustomer;
        public CustomerService(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {
            repoCustomer = factoryRepository.CreateRepository<Customer>();
        }

        public Customer CreateCustomer(string userID)
        {
            var objCustomer = new Customer
            {
                UserID = userID
            };
            repoCustomer.Add(objCustomer);
            return objCustomer;
        }

        public Customer GetCustomerByUserID(string userID)
        {
            Customer customer = repoCustomer.GetQuery(false)
                                            .Where(c => c.UserID == userID)
                                            .SingleOrDefault();

            return customer;
        }
    }
}
