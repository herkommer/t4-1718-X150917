using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise150917
{
    public partial class CarsInStock : Form
    {
        private Stock _stock = new Stock();

        List<string> ColorCheck = new List<string>();

        public CarsInStock()
        {
            InitializeComponent();

            //Set-up form
            Text = "Cars in stock";
            button1.Text = "Milage data";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            

            foreach (Car c in _stock.Cars)
            {
                listBox1.Items.Add(c);

                if (!ColorCheck.Contains(c.Color))
                {
                    comboBox1.Items.Add(c);
                    ColorCheck.Add(c.Color);
                }
                comboBox1.DisplayMember = "Color";
            }
            
            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;
                textBox1.Text = "Tillverkare: " + c.Make;
                textBox2.Text = "Modell: " + c.Model;
                textBox3.Text = "Färg: " + c.Color;
                textBox4.Text = "Mätarställning: " + c.Milage;

            });

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)comboBox1.SelectedItem;
                MessageBox.Show(string.Format("We have {0} {1} cars in stock", ColorCount(c), c.Color));
            });

            button1.Click += new EventHandler((sender, e) =>
            {
                MessageBox.Show(string.Format("We have {0} cars in stock, average milage is {1} km, the lowest milage is {2} km and the higest is {3} km.",
                   _stock.Cars.Count(),
                   _stock.Cars.Average(x=>x.Milage),
                   _stock.Cars.Min(x=>x.Milage),
                   _stock.Cars.Max(x=>x.Milage)));

            });
            
        }
        public int ColorCount(Car c)
        {
            int answer;
            string color = c.Color;
            answer = _stock.Cars.Count(x => x.Color == string.Format("{0}", color));
            return answer;
        }
    }
}
