using i39mo9_week08_irf.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i39mo9_week08_irf.Abstractions
{
    public class PresentFactory : IToyFactory
    {
        public Color RibbonColor { get; set; }
        public Color BoxColor { get; set; }

        public Toy CreateNew()
        {
            return new Present(RibbonColor, BoxColor);
        }
    }
}
