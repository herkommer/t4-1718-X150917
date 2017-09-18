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
            button1.Text = "Info";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            foreach (Car c in _stock.Cars)
            {
                listBox1.Items.Add(c);
            }
            foreach (Car c in _stock.Cars)
            {
                listBox2.Items.Add(c);
                listBox2.DisplayMember = "color";
            }

            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;
                textBox1.Text = "Make: " + c.Make;
                textBox2.Text = "Modell: " + c.Model;
                textBox3.Text = "Color: " + c.Color;
                textBox4.Text = "Milage: " + c.Milage;
            }
            );
            listBox2.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox2.SelectedItem;
                MessageBox.Show(String.Format("We have {0} {1}", _stock.Cars.Count(x => x.Color == String.Format("{0}", c.Color)), c.Color));
            }
            );
            button1.Click += new EventHandler((sender, e) =>
            {
                MessageBox.Show(string.Format
                    ("We have {0} cars in stock, average milage is {1}km, the lowest milage is {2}km and the highest is {3}km",
                     _stock.Cars.Count(), _stock.Cars.Average(x => x.Milage), _stock.Cars.Min(x => x.Milage), _stock.Cars.Max(x => x.Milage)));
            }
            );

        }

    }
}
