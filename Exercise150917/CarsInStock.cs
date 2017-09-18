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
            
            comboBox1.Text = "Colors";

            foreach (Car c in _stock.Cars)
            {
                listBox1.Items.Add(c);
                if(!comboBox1.Items.Contains(c.Color))
                comboBox1.Items.Add(c.Color);
            }
            

            listBox1.SelectedIndexChanged += new EventHandler((sender, e) => {
                Car c = (Car)listBox1.SelectedItem;
                textBox1.Text = "Make: " + c.Make;
                textBox2.Text = "Model: " + c.Model;
                textBox3.Text = "Color: " + c.Color;
                textBox4.Text = "Milage: " + c.Milage;
            });

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                string carColor = (string)comboBox1.SelectedItem;
                int colorCounter = 0;

                foreach (Car car in _stock.Cars)
                {
                    if (car.Color == carColor)
                        colorCounter++;
                }
                MessageBox.Show(string.Format("There are {0} {1} cars in stock", colorCounter, carColor));
            });

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) => {

                

            });

            button1.Text = "Milage data";
            
            button1.Click += new EventHandler((sender, e) => {
 
                MessageBox.Show(string.Format("There are {0} cars in stock, average milage {1} km, highest milage {2} km, lowest milage {3} km"
                                    ,_stock.Cars.Count
                                    ,_stock.Cars.Average(x => x.Milage)
                                    ,_stock.Cars.Max(x => x.Milage)
                                    ,_stock.Cars.Min(x => x.Milage)));
            });
        }
    }
}
