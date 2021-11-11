using i39mo9_week08_irf.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i39mo9_week08_irf.Entities
{
    public class Factory: IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
