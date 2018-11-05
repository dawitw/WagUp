using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Gadget : AbstractDevice
    {
        public DevicePower PoweredBy { get; set; }
        public List<Widget> Components { get; set; }
        public List<IComponent> FixedComponents { get; set; }
        public decimal FixedComponentsTotalPrice { get; set; }

        public Gadget()
            : this(DeviceFinish.Plain, DeviceSize.Small, 0)
        {
        }

        public Gadget(DeviceFinish finish)
            : this(finish, DeviceSize.Small, 0)
        {
        }

        public Gadget(DeviceSize size)
            : this(DeviceFinish.Plain, size, 0)
        {
        }

        public Gadget(DeviceFinish finish, DeviceSize size)
            : this(finish, size, 0)
        {
        }

        public Gadget(DeviceFinish finish, DeviceSize size, int serialNumber)
        {
            SerialNumber = serialNumber;
            Name = "Gadget";
            Price = 0.00m;
            FixedComponentsTotalPrice = 0.00m;
            Finish = finish;
            Size = size;
            Components = new List<Widget>();
            AddFixedComponents();
        }

        private void AddComponent(Widget component)
        {
            Components.Add(component);
            Price += component.Price;
        }

        public void AddComponents(Widget component, int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddComponent(component);
            }
        }

        public void AddComponents(Widget component, int count, ArrayList deviceIDs)
        {
            for (int i = 0; i < count; i++)
            {
                component.SerialNumber = int.Parse(deviceIDs[i].ToString());
                AddComponent(component);
            }
        }

        private void AddComponents(IComponent component, int count)
        {
            for (int i = 0; i < count; i++)
            {
                FixedComponents.Add(component);
                FixedComponentsTotalPrice += component.Price;
                Price += component.Price;
            }
        }        

        private void AddFixedComponents()
        {
            FixedComponents = new List<IComponent>();

            switch (Size)
            {
                case DeviceSize.Small:
                    AddComponents(new Button(), 2);
                    AddComponents(new Switch(), 1);
                    break;
                case DeviceSize.Medium:
                    AddComponents(new Button(), 5);
                    AddComponents(new Light(), 3);
                    AddComponents(new Switch(), 1);
                    break;
                case DeviceSize.Large:
                    AddComponents(new Button(), 7);
                    AddComponents(new Light(), 6);
                    AddComponents(new Switch(), 5);
                    break;
            }
        }
    }
}
