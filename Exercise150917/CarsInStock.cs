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

            foreach (Car c in _stock.Cars)
            {
                listBox1.Items.Add(c);

                listBox2.Items.Add(c.Color);
            }

            

            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;

                textBox1.Text = "Make: " + c.Make;
                textBox2.Text = "Model: " + c.Model;
                textBox3.Text = "Color: " + c.Color;
                textBox4.Text = string.Format("Milage: {0} miles", c.Milage);
            });

            listBox2.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                string color = (string)listBox2.SelectedItem;
                int counter = 0;
                foreach (Car c in _stock.Cars)
                {
                    if (c.Color == color)
                        counter++;
                }

                MessageBox.Show(string.Format("We have {0} {1} cars in stock", counter, color));
            });
        }
    }
}
