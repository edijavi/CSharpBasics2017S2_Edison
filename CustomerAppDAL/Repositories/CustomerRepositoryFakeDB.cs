﻿using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppEntity;
using System.Linq;

namespace CustomerAppDAL.Repositories
{
    class CustomerRepositoryFakeDB : ICustomerRepository
    {
        #region Fake DB
        private static int Id = 1;
        private static List<Customer> Customers = new List<Customer>();
        #endregion 

        public Customer Create(Customer cust)
        {
            Customer newCust;
            Customers.Add(newCust = new Customer()
            {
                Id = Id++,
                FistName = cust.FistName,
                LastName = cust.LastName,
                Address = cust.Address
            });
            return newCust;
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);
            Customers.Remove(cust);
            return cust;
        }

        public Customer Get(int Id)
        {
            return Customers.FirstOrDefault(x => x.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(Customers);
        }
    }
}
