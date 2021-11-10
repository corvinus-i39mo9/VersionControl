using i39mo9_week08_irf.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i39mo9_week08_irf.Entities
{
    public class Car: Toy
    {
        protected override void DrawImage(Graphics gr)
        {
            Image imageFile = Image.FromFile("Images/car.png");
            gr.DrawImage(imageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}
