using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Widget : AbstractDevice, IComponent
    {
        public List<IComponent> Components { get; set; }

        public Widget()
            : this(DeviceFinish.Plain, DeviceSize.Small, 0)
        {            
        }

        public Widget(DeviceFinish finish)
            : this(finish, DeviceSize.Small, 0)
        {
        }

        public Widget(DeviceSize size)
            : this(DeviceFinish.Plain, size, 0)
        {
        }

        public Widget(DeviceFinish finish, DeviceSize size)
            : this(finish, size, 0)
        {   
        }

        public Widget(DeviceFinish finish, DeviceSize size, int serialNumber)
        {
            SerialNumber = serialNumber;
            Name = "Widget";
            Price = 0.00m;
            Finish = finish;
            Size = size;
            AddComponents();
        }

        private void AddComponent(IComponent component)
        {
            Components.Add(component);
            Price += component.Price;
        }

        private void AddComponents()
        {
            Components = new List<IComponent>();

            switch (Size)
            {
                case DeviceSize.Small:
                    AddComponents(2, 1, 3);
                    break;
                case DeviceSize.Medium:
                    AddComponents(4, 3, 5);
                    break;
                case DeviceSize.Large:
                    AddComponents(9, 2, 4);                    
                    break;
            }
        }

        private void AddComponents(int gearCount, int leverCount, int springCount)
        {
            AddGears(gearCount);
            AddLevers(leverCount);
            AddSprings(springCount);
        }

        private void AddGears(int gearCount)
        {
            for (int i=0; i < gearCount; i++)
            {
                AddComponent(new Gear());
            }
        }

        private void AddLevers(int leverCount)
        {
            for (int i = 0; i < leverCount; i++)
            {
                AddComponent(new Lever());
            }
        }

        private void AddSprings(int springCount)
        {
            for (int i = 0; i < springCount; i++)
            {
                AddComponent(new Spring());
            }
        }
    }
}
