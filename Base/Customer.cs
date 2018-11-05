using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public CustomerType CustomerType { get; set; }

        public Customer()
            : this(0, "", CustomerType.Retail)
        {
        }

        public Customer(int customerID)
            : this(customerID, "", CustomerType.Retail)
        {
        }

        public Customer(string customerName)
            : this(0, customerName, CustomerType.Retail)
        {
        }

        public Customer(int customerID, string customerName, CustomerType customerType)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerType = customerType;
        }
    }
}
