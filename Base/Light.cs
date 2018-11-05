using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Light : IComponent
    {
        public string Name
        {
            get { return "Light"; }
        }

        public decimal Price
        {
            get { return 310.00m; }
        }
    }
}
