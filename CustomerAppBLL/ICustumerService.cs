using CustomerAppBLL.BusinessObjects;
using System.Collections.Generic;


namespace CustomerAppBLL
{
/// <summary>
/// I made a contract!!!
/// </summary>
    public interface ICustumerService
    {
        //C
        CustomerBO Create(CustomerBO cust);
        //R
        List<CustomerBO> GetAll();
        CustomerBO Get(int Id);
        //U
        CustomerBO Update(CustomerBO cust);
        //D
        CustomerBO Delete(int Id);

    }
}
