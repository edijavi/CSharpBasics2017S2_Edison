using CustomerAppEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
/// <summary>
/// I made a contract!!!
/// </summary>
    public interface ICustumerService
    {
        //C
        Customer Create(Customer cust);
        //R
        List<Customer> GetAll();
        Customer Get(int Id);
        //U
        Customer Update(Customer cust);
        //D
        Customer Delete(int Id);

    }
}
