using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identification
{
    public class IDNumberGenerator
    {
        private static volatile IDNumberGenerator instance;
        public static object synchronizationRoot = new object();
        private int _customerIDNumber = 1000;
        private int _deviceSerialNumber = 12000;
        private int _invoiceNumber = 100;

        public static IDNumberGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchronizationRoot)
                    {
                        if(instance == null)
                        {
                            instance = new IDNumberGenerator();
                        }
                    }
                }
                return instance;
            }
        }

        private IDNumberGenerator() { }

        public virtual int NextCustomerIDNumber
        {
            get { return ++_customerIDNumber; }
        }

        public virtual int NextDeviceSerialNumber
        {
            get { return ++_deviceSerialNumber; }
        }

        public virtual int NextInvoiceNumber
        {
            get { return ++_invoiceNumber; }
        }
    }
}
