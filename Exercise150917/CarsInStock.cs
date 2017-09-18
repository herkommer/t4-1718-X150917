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

        List<string> colorCheck = new List<string>();

        public CarsInStock()
        {
            

            InitializeComponent();

            //Set-up form
            Text = "Cars in stock";
            button1.Text = "Milage Data";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            foreach (Car c in _stock.Cars)
            {
                listBox1.Items.Add(c);

                if (!colorCheck.Contains(c.Color))
                {
                    comboBox1.Items.Add(c);
                    colorCheck.Add(c.Color);
                }
                comboBox1.DisplayMember = "Color";
            }

            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;
                Display(c);
            }
            );

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)comboBox1.SelectedItem;
                MessageBox.Show(string.Format("We have {0} {1} cars in stock", colorBox(c), c.Color));
            }
            );

            button1.Click += new EventHandler((sender, e) =>
            {
                MessageBox.Show(string.Format("We have {0} cars in stock, average milage is {1} km, the lowest milage is {2} km and the highest is {3} km ",
                _stock.Cars.Count(),
                _stock.Cars.Average(x => x.Milage),
                _stock.Cars.Min(x => x.Milage),
                _stock.Cars.Max(x => x.Milage)
            ));
            });
        }

        private int colorBox(Car c)
        {
            int answer;
            string color = c.Color;
            answer = _stock.Cars.Count(x => x.Color == string.Format("{0}", color));
            return answer;
        }

        private void Display(Car c)
        {
            textBox1.Text = "Make: " + c.Make;
            textBox2.Text = "Model: " + c.Model;
            textBox3.Text = "Color: " + c.Color;
            textBox4.Text = "Milage: " + c.Milage;
        }
    }
}
