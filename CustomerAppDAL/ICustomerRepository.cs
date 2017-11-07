using CustomerAppDAL.Entities;
using System.Collections.Generic;

namespace CustomerAppDAL
{
    public interface ICustomerRepository
    {
        //C
        Customer Create(Customer cust);
        //R
        List<Customer> GetAll();
        Customer Get(int Id);
        //U(No update for Repository. It will be the task of UOW)
        //D
        Customer Delete(int Id);
    }
}
