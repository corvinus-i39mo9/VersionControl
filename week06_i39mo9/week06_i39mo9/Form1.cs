using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using week06_i39mo9.Entities;
using week06_i39mo9.MNBServiceReference;

namespace week06_i39mo9
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            ValutakBetoltese();
            RefreshData();
        }

        private void RefreshData()
        {
            Rates.Clear();
            dgw.DataSource = Rates;
            fuggveny2(fuggveny());
            diagram();
        }

        private string fuggveny()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;
        }

        private void fuggveny2(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        private void diagram()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Rates.Clear();
            dgw.DataSource = Rates;
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = dateTimePicker1.Value.ToString(),
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var eredmeny = response.GetExchangeRatesResult;
            fuggveny2(eredmeny);
            diagram();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Rates.Clear();
            dgw.DataSource = Rates;

            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = dateTimePicker2.Value.ToString()
            };
            var response = mnbService.GetExchangeRates(request);
            var eredmeny = response.GetExchangeRatesResult;
            fuggveny2(eredmeny);
            diagram();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rates.Clear();
            dgw.DataSource = Rates;
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var eredmeny = response.GetExchangeRatesResult;
            fuggveny2(eredmeny);
            diagram();
        }
        private void ValutakBetoltese()
        {
            comboBox1.DataSource = Currencies;
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetCurrenciesRequestBody();
            var response = mnbService.GetCurrencies(request);
            var result = response.GetCurrenciesResult;
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                for (int i = 0; i < element.ChildNodes.Count; i++)
                {
                    var childElement = (XmlElement)element.ChildNodes[i];
                    var curr = childElement.InnerText;
                    Currencies.Add(curr);
                }
                RefreshData();
            }
        }
    }
}
