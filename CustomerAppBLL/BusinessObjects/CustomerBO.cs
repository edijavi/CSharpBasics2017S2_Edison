using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    public class CustomerBO
    {
        public int Id { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FistName} {LastName}"; }
                
        }
        
        public string Address { get; set; }
    }
}
