using i39mo9_week08_irf.Abstractions;
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
        private Toy _nextToy;

        private List<Toy> _toys = new List<Toy>();

        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                DisplayNext();
            }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var b in _toys)
            {
                b.MoveToy();
                if (b.Left > maxPosition)
                    maxPosition = b.Left;
            }

            if (maxPosition > 1000)
            {
                var maxToy = _toys[0];
                mainPanel.Controls.Remove(maxToy);
                _toys.Remove(maxToy);
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var t = Factory.CreateNew();
            _toys.Add(t);
            t.Left = -t.Width;
            mainPanel.Controls.Add(t);
        }

        private void buttonCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void buttonBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = buttonSzinvalaszto.BackColor
            };
        }

        void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        private void buttonSzinvalaszto_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var clr = new ColorDialog();
            clr.Color = buttonSzinvalaszto.BackColor;
            if (clr.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            button.BackColor = clr.Color;
        }

        private void buttonPresent_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory
            {
                RibbonColor = button1.BackColor,
                BoxColor = button2.BackColor
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var clr = new ColorDialog();
            clr.Color = buttonSzinvalaszto.BackColor;
            if (clr.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            button.BackColor = clr.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var clr = new ColorDialog();
            clr.Color = buttonSzinvalaszto.BackColor;
            if (clr.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            button.BackColor = clr.Color;
        }
    }
}
