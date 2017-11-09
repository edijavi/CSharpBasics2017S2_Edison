using CustomerAppBLL.Services;
using CustomerAppDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public ICustumerService CustumerService
        {
            get { return new CustomerService(new DALFacade()); }
        }
    }
}
