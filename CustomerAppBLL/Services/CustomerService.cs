using System;
using System.Collections.Generic;
using CustomerAppDAL;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System.Linq;
using CustomerAppBLL.Converters;

namespace CustomerAppBLL.Services
{
    class CustomerService : ICustumerService
    {
        CustomerConverter conv = new CustomerConverter();
       
        DALFacade facade;
        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();
                return conv.Convert(newCust);
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newCust);
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.CustomerRepository.Get(Id));
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer ->CustomerBO
                //return uow.CustomerRepository.GetAll();
                //Se usa landa expresion pero se puede simplificar
                return uow.CustomerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                customerFromDb.FistName = cust.FistName;
                customerFromDb.LastName = cust.LastName;
                customerFromDb.Address = cust.Address;
                uow.Complete();
                return conv.Convert(customerFromDb);

            }
        }

        
    }
}
