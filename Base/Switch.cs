using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Switch : IComponent
    {
        public string Name
        {
            get { return "Switch"; }
        }

        public decimal Price
        {
            get { return 330.00m; }
        }
    }
}
