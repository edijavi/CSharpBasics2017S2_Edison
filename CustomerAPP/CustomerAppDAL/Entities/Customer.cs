using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
