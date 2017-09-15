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

        public CarsInStock()
        {
            InitializeComponent();

            //Set-up form
            Text = "Cars in stock";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button1.Text = "Milage Data";
            comboBox1.Text = "Colors";

            foreach (Car c in _stock.Cars)
            {
                listBox1.Items.Add(c);
                if (!comboBox1.Items.Contains(c.Color))
                    comboBox1.Items.Add(c.Color);
            }


            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;

                textBox1.Text = "Make: " + c.Make;
                textBox2.Text = "Model: " + c.Model;
                textBox3.Text = "Color: " + c.Color;
                textBox4.Text = string.Format("Milage: {0} km", c.Milage);
            });

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                string color = (string)comboBox1.SelectedItem;
                int counter = 0;
                foreach (Car c in _stock.Cars)
                {
                    if (c.Color == color)
                        counter++;
                }

                MessageBox.Show(string.Format("We have {0} {1} cars in stock", counter, color));
            });

            button1.Click += new EventHandler((sender, e) =>
            {
                int carCount = _stock.Cars.Count;
                double avg = _stock.Cars.Average(q => q.Milage);
                int min = _stock.Cars.Min(q => q.Milage);
                int max = _stock.Cars.Max(q => q.Milage);


                
                MessageBox.Show(string.Format("We have {0} cars in stock, average milage is {1} km, " +
                    "the lowest milage is {2} km and the highest is {3} km.", carCount, avg, min, max));
            });
        }
    }
}
