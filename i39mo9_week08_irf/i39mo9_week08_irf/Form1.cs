using i39mo9_week08_irf.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace i39mo9_week08_irf
{
    public partial class Form1 : Form
    {
        private List<Toy> _balls = new List<Toy>();

        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var b in _balls)
            {
                b.MoveBall();
                if (b.Left > maxPosition)
                    maxPosition = b.Left;
            }

            if (maxPosition > 1000)
            {
                var maxBall = _balls[0];
                mainPanel.Controls.Remove(maxBall);
                _balls.Remove(maxBall);
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var b = Factory.CreateNew();
            _balls.Add(b);
            mainPanel.Controls.Add(b);
            b.Left = -b.Width;
        }
    }
}
