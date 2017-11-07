using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppEntity;
using CustomerAppDAL;
using System.Linq;

namespace CustomerAppBLL.Services
{
    class CustomerService : ICustumerService
    {
        ICustomerRepository repo;
        public CustomerService(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public Customer Create(Customer cust)
        {
            return repo.Create(cust);
        }

        public Customer Delete(int Id)
        {

            return repo.Delete(Id); 
        }

        public Customer Get(int Id)
        {
            return repo.Get(Id); 
        }

        public List<Customer> GetAll()
        {
            return repo.GetAll(); 
        }

        public Customer Update(Customer cust)
        {
            var customerFromDb = Get(cust.Id);
            if(customerFromDb == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            customerFromDb.FistName = cust.FistName;
            customerFromDb.LastName = cust.LastName;
            customerFromDb.Address = customerFromDb.Address;
            //save Changes
            return customerFromDb;
        }
    }
}
