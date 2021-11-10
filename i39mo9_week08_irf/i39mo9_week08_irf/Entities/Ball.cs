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
    public class Ball: Toy
    {
        protected override void DrawImage(Graphics gr)
        {
            gr.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }
    }
}
