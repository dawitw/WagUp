using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Lever : IComponent
    {
        public string Name
        {
            get { return "Lever"; }
        }

        public decimal Price
        {
            get { return 260.00m; }
        }
    }
}
