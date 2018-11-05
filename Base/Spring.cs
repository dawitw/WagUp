using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Spring : IComponent
    {
        public string Name
        {
            get { return "Spring"; }
        }

        public decimal Price
        {
            get { return 520.00m; }
        }
    }
}
