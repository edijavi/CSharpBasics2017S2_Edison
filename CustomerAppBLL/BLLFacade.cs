using CustomerAppBLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public ICustumerService GetCustumerService()
        {
            return new CustomerService();
        }

        public ICustumerService CustumerService
        {
            get { return new CustomerService(); }
        }
    }
}
