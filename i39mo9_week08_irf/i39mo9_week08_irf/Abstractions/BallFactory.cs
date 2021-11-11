using i39mo9_week08_irf.Abstractions;
using i39mo9_week08_irf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i39mo9_week08_irf.Abstractions
{
    public class BallFactory: IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
