using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identification;
using Base;
using Sale;

namespace WagUp
{
    class Program
    {
        static IDNumberGenerator iDNumberGenerator = IDNumberGenerator.Instance;

        static void Main(string[] args)
        {
            int iEntry;
            int finish;
            int size;
            string userInput;
            Gadget gadget;
            Order order;

            do
            {
                iEntry = 0;
                finish = 0;
                size = 0;
                userInput = "";
                gadget = new Gadget();
                order = new Order();

                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\tWelcome to Wag Corp's Ordering System\n");

                iEntry = GetUserInputInteger(1, 2, "\n1 - Manufacturer\n2 - Retail\nType of customer: ");
                order.Customer.CustomerType = (CustomerType)iEntry;

                Console.Write("\nName of the customer/business: ");
                order.Customer.CustomerName = Console.ReadLine();

                // Prompts user to enter gadget data.
                do
                {
                    finish = GetUserInputInteger(1, 3, "\n1 - Painted\n2 - Plain\n3 - Plated\nFinish of gadget: ");

                    iEntry = GetUserInputInteger(1, 3, "\n1 - Small\n2 - Medium\n3 - Large\nSize of gadget: ");

                    gadget = new Gadget((DeviceFinish)finish, (DeviceSize)iEntry, IDNumberGenerator.Instance.NextDeviceSerialNumber);

                    // Behavior/prompt selection depends on the size of the gadget.
                    switch (iEntry)
                    {
                        case 1:
                            if (order.Customer.CustomerType.Equals(CustomerType.Retail))
                            {
                                gadget.PoweredBy = DevicePower.Battery;

                                // Prompts user to enter widget data.
                                finish = GetUserInputInteger(1, 3, "\n1 - Painted\n2 - Plain\n3 - Plated\nFinish of widgets: ");

                                gadget.AddComponents(new Widget((DeviceFinish)finish, DeviceSize.Small,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 1);
                                gadget.AddComponents(new Widget((DeviceFinish)finish, DeviceSize.Medium,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 1);
                            }
                            else
                            {
                                gadget.PoweredBy = DevicePower.Battery;

                                GetUserInputWidget(gadget);
                            }
                            break;
                        case 2:
                            if (order.Customer.CustomerType.Equals(CustomerType.Retail))
                            {
                                // Adds widgets to a gadget.
                                gadget.AddComponents(new Widget(DeviceFinish.Plain, DeviceSize.Small,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 2, GetNewDeviceIDs(2));
                                gadget.AddComponents(new Widget(DeviceFinish.Plain, DeviceSize.Medium,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 2, GetNewDeviceIDs(2));
                                gadget.AddComponents(new Widget(DeviceFinish.Plain, DeviceSize.Large,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 1);

                                // Prompts user to enter power data.
                                gadget.PoweredBy = PromptForPoweredBy(gadget.Size, "\n1 - Battery\n2 - Solar\nPowered by: ");
                            }
                            else
                            {
                                gadget.PoweredBy = PromptForPoweredBy(gadget.Size, "\n1 - Battery\n2 - Solar\nPowered by: ");

                                GetUserInputWidget(gadget);
                            }
                            break;
                        case 3:
                            if (order.Customer.CustomerType.Equals(CustomerType.Retail))
                            {
                                gadget.AddComponents(new Widget(DeviceFinish.Plain, DeviceSize.Small,
                                                                IDNumberGenerator.Instance.NextDeviceSerialNumber), 3, GetNewDeviceIDs(3));
                                gadget.AddComponents(new Widget(DeviceFinish.Plain, DeviceSize.Medium,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 6, GetNewDeviceIDs(6));
                                gadget.AddComponents(new Widget(DeviceFinish.Plain, DeviceSize.Large,
                                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 3, GetNewDeviceIDs(3));

                                gadget.PoweredBy = PromptForPoweredBy(gadget.Size, "\n1 - Generator\n2 - Solar\nPowered by: ");
                            }
                            else
                            {
                                gadget.PoweredBy = PromptForPoweredBy(gadget.Size, "\n1 - Generator\n2 - Solar\nPowered by: ");

                                GetUserInputWidget(gadget);
                            }
                            break;
                        default:
                            Console.WriteLine("\n**Please enter a valid value.");
                            break;
                    }

                    order.Gadgets.Add(gadget);

                    userInput = "";
                    Console.WriteLine("\nPress any key to add another gadget or press Q to continue.");
                    userInput = Console.ReadLine();
                } while (!userInput.ToLower().Equals("q"));

                order.Customer.CustomerID = iDNumberGenerator.NextCustomerIDNumber;
                Console.Clear();
                Console.WriteLine(order.CreateReceipt());

                userInput = "";
                Console.WriteLine("\nPress any key to continue or press Q to quit.");
                userInput = Console.ReadLine();
            } while (!userInput.ToLower().Equals("q"));
        }

        private static Gadget GetUserInputWidget(Gadget gadget)
        {
            int finish;
            int size;
            string userInput;

            do
            {
                finish = GetUserInputInteger(1, 3, "\n1 - Painted\n2 - Plain\n3 - Plated\nFinish of widget: ");
                size = GetUserInputInteger(1, 3, "\n1 - Small\n2 - Medium\n3 - Large\nSize of widget: ");

                gadget.AddComponents(new Widget((DeviceFinish)finish, (DeviceSize)size,
                    IDNumberGenerator.Instance.NextDeviceSerialNumber), 1);

                userInput = "";
                Console.WriteLine("\nPress any key to add another widget or press Q to continue.");
                userInput = Console.ReadLine();
            } while (!userInput.ToLower().Equals("q"));

            return gadget;
        }

        private static ArrayList GetNewDeviceIDs(int count)
        {
            ArrayList deviceIDs = new ArrayList(count);
            
            for (int i = 0; i < count; i++)
            {
                deviceIDs.Add(iDNumberGenerator.NextDeviceSerialNumber);
            }

            return deviceIDs;
        }

        private static int GetUserInputInteger(int minValue, int maxValue, string prompt)
        {
            bool validEntry = false;
            string entry = "";
            int iEntry = 0;

            do
            {
                Console.Write(prompt.ToString());
                entry = Console.ReadLine();

                try
                {
                    iEntry = int.Parse(entry);

                    if (!(iEntry < minValue || iEntry > maxValue))
                    {
                        validEntry = true;                        
                    }
                    else
                    {
                        Console.WriteLine("\n**Please enter a valid value.**");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n**Please enter a valid value.**");
                }
            } while (!validEntry);

            return iEntry;
        }

        private static DevicePower PromptForPoweredBy(DeviceSize size, string prompt)
        {
            bool validEntry = false;
            string entry = "";
            DevicePower poweredBy = DevicePower.Solar;

            do
            {
                Console.Write(prompt.ToString());
                entry = Console.ReadLine();

                try
                {
                    switch (Int32.Parse(entry))
                    {
                        case 1:
                            if (size.Equals(DeviceSize.Medium))
                            {
                                poweredBy = DevicePower.Battery;

                                validEntry = true;
                            }
                            else
                            {
                                poweredBy = DevicePower.Generator;

                                validEntry = true;
                            }
                            break;
                        case 2:
                            if (size.Equals(DeviceSize.Medium))
                            {
                                poweredBy = DevicePower.Solar;

                                validEntry = true;
                            }
                            else
                            {
                                poweredBy = DevicePower.Solar;

                                validEntry = true;
                            }
                            break;
                        default:
                            Console.WriteLine("\n**Please enter a valid value.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n**Please enter a valid value.");
                }
            } while (!validEntry);

            return poweredBy;
        }
    }
}
