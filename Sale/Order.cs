using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identification;
using Base;

namespace Sale
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        //public IList<Widget> Widgets { get; set; }
        public List<Gadget> Gadgets { get; set; }
        public decimal TotalPrice { get; set; }

        public Order()
        {
            TotalPrice = 0.00m;

            OrderDate = DateTime.Now;

            Customer = new Customer();

            Gadgets = new List<Gadget>();
        }

        public Order(Customer customer, List<Widget> widgets, List<Gadget> gadgets)
        {
            TotalPrice = 0.00m;

            OrderDate = DateTime.Now;

            Customer = customer;
            //Widgets = widgets;
            Gadgets = gadgets;
        }

        public string CreateReceipt()
        {
            decimal totalPrice = 0.00m;
            StringBuilder receipt = new StringBuilder();

            if (Gadgets.Count > 0)
            {
                receipt.Append("\t\t\t\t\t\t\tWag Corporation\n\nOrder date: ");
                receipt.Append(OrderDate.ToString());
                receipt.Append("\n\nCustomer: ");
                receipt.Append(Customer.CustomerName.ToString());
                receipt.Append("\n\nCustomer ID Number: ");
                receipt.Append(Customer.CustomerID.ToString());
                receipt.Append("\n\nItems:");

                foreach (Gadget gadget in Gadgets)
                {
                    receipt.Append("\n\n");
                    receipt.Append(gadget.Name);
                    receipt.Append(" | ");
                    receipt.Append(gadget.SerialNumber);
                    receipt.Append(" | ");
                    receipt.Append(gadget.Size);
                    receipt.Append(" | ");
                    receipt.Append(gadget.Finish);
                    receipt.Append(" | ");
                    receipt.Append(gadget.PoweredBy);
                    receipt.Append("\t\t\t\t\t\t\t\t");
                    receipt.Append(gadget.Price);

                    foreach (IComponent component in gadget.FixedComponents)
                    {
                        receipt.Append("\n\t|__ ");
                        receipt.Append(component.Name);
                        receipt.Append("\t\t\t\t");
                        receipt.Append(component.Price);
                    }

                    foreach (Widget widget in gadget.Components)
                    {
                        receipt.Append("\n\t|__ ");
                        receipt.Append(widget.Name);
                        receipt.Append(" | ");
                        receipt.Append(widget.SerialNumber);
                        receipt.Append(" | ");
                        receipt.Append(widget.Size);
                        receipt.Append(" | ");
                        receipt.Append(widget.Finish);
                        receipt.Append("\t\t\t\t\t");
                        receipt.Append(widget.Price);

                        foreach (IComponent component in widget.Components)
                        {
                            receipt.Append("\n\t\t|__ ");
                            receipt.Append(component.Name);
                            receipt.Append("\t\t\t");
                            receipt.Append(component.Price);
                        }
                    }

                    totalPrice += gadget.Price;
                }

                receipt.Append("\n\nTotal Price: ");
                receipt.Append(totalPrice.ToString());
            }
            else
            {
                receipt.Append("No order found.");
            }

            return receipt.ToString();
        }
    }
}
