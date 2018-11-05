using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Gear : IComponent
    {
        public string Name
        {
            get { return "Gear"; }
        }

        public decimal Price
        {
            get { return 1470.00m; }
        }
    }
}
