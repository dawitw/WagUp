using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Button : IComponent
    {
        public string Name
        {
            get { return "Button"; }
        }

        public decimal Price
        {
            get { return 110.00m; }
        }
    }
}
