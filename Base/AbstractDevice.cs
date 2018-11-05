using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace Base
{
    public abstract class AbstractDevice
    {
        public int SerialNumber { get; set; }
        public DeviceFinish Finish { get; set; }
        public DeviceSize Size { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public AbstractDevice()
            : this(DeviceFinish.Plain, DeviceSize.Small, 0)
        {
        }

        public AbstractDevice(DeviceFinish finish)
            : this(finish, DeviceSize.Small, 0)
        {
        }

        public AbstractDevice(DeviceSize size)
            : this(DeviceFinish.Plain, size, 0)
        {
        }

        public AbstractDevice(DeviceFinish finish, DeviceSize size)
            : this(finish, size, 0)
        {
        }

        public AbstractDevice(DeviceFinish finish, DeviceSize size, int serialNumber)
        {
            SerialNumber = serialNumber;
            Finish = finish;
            Size = size;
        }
    }
}
