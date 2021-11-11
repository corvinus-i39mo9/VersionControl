using i39mo9_week08_irf.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i39mo9_week08_irf.Entities
{
    public class Present : Toy
    {
        public SolidBrush RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }

        public Present(Color color1, Color color2)
        {
            RibbonColor = new SolidBrush(color1);
            BoxColor = new SolidBrush(color2);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 0, 0, Width, Height);
            g.FillRectangle(RibbonColor, Width/5, 0, Width/5, Height);
            g.FillRectangle(RibbonColor, 0, Height/5, Width, Height / 5);
        }
    }
}
