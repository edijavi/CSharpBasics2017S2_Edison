﻿using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; internal set; };
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            CustomerRepository = new CustomerRepositoryEFMemory(context);
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}