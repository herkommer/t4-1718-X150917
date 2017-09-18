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
            button1.Text = "Mileage Data";

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
                    ColorCheck.Contains(c.Color);
                }
                comboBox1.DisplayMember = "Color";
            }

            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
              {
                  Car c = (Car)listBox1.SelectedItem;
              });

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)comboBox1.SelectedItem;
                MessageBox.Show(string.Format("We have {0} {1} cars in stock", Count(c), c.Color));
            });

            button1.Click += new EventHandler((sender, e) =>
            {
                MessageBox.Show(string.Format("We have {0} cars in stock,average mileage is {1} km, the lowest mileage is {2} km and the highest is {3} km.",
                                                            _stock.Cars.Count(),
                                                            _stock.Cars.Average(x => x.Milage),
                                                            _stock.Cars.Min(x => x.Milage),
                                                            _stock.Cars.Max(x => x.Milage)));
            });
        }


        private int Count(Car c)
        {
            int answer;
            string color = c.Color;
            answer = _stock.Cars.Count(x => x.Color == string.Format("{0}", color));
            return answer;
        }

        private void Display(Car c)
        {
            textBox1.Text = "Märke: " + c.Make;
            textBox2.Text = "Modell: " + c.Model;
            textBox3.Text = "Färg: " + c.Color;
            textBox4.Text = "Mätarställning: " + c.Milage;

        }
    }
}
