using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace week04_i39mo9
{
    public partial class Form1 : Form
    {
        List<Flat> flats;
        RealEstateEntities context = new RealEstateEntities();
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        public void LoadData()
        {
            flats = context.Flats.ToList();
        }

        public void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        public void CreateTable()
        {
            string[] headers = new string[] {
     "Kód",
     "Eladó",
     "Oldal",
     "Kerület",
     "Lift",
     "Szobák száma",
     "Alapterület (m2)",
     "Ár (mFt)",
     "Négyzetméter ár (Ft/m2)"
            };
            object[,] values = new object[flats.Count, headers.Length];

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }

            int szamlalo = 0;
            foreach (Flat f in flats)
            {
                values[szamlalo, 0] = f.Code;
                values[szamlalo, 1] = f.Vendor;
                values[szamlalo, 2] = f.Side;
                values[szamlalo, 3] = f.District;
                values[szamlalo, 4] = f.Elevator;
                values[szamlalo, 5] = f.NumberOfRooms;
                values[szamlalo, 6] = f.FloorArea;
                values[szamlalo, 7] = f.Price;
                values[szamlalo, 8] = "";
                szamlalo++;
            }
            xlSheet.get_Range(
             GetCell(2, 1),
             GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
            xlSheet.get_Range(
             GetCell(2, 9),
             GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = "=H2*G2";

        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
