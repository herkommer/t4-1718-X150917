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
        List<Car> _cars = new List<Car>();

        public CarsInStock()
        {

            InitializeComponent();
            button1.Text = "Milage data";

            //Set-up form
            Text = "Cars in stock";

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
                listBox2.DisplayMember = "Color";
            }

            //EventHandelers
            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;
                Display(c);
            });

            listBox2.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox2.SelectedItem;
                MessageBox.Show(string.Format("We have {0} {1} cars in stock!", ColorList(c), c.Color));
            });

            button1.Click += new EventHandler((sender, e) =>
            {
                MessageBox.Show(string.Format("We have {0} cars in stock, average milage is {1} km" +
                    ", the lowest milage is {2} km and the highest is {3} km."
                    , _stock.Cars.Count()
                    , _stock.Cars.Average(x => x.Milage)
                    , _stock.Cars.Min(x => x.Milage)
                    , _stock.Cars.Max(x => x.Milage)));
            });
        }

        //Listan bilarnas färger (höger)
        private int ColorList(Car c)
        {
            int answer;
            string color = c.Color;
            answer = _stock.Cars.Count(x => x.Color == string.Format("{0}", color));
            return answer;
        }

        //Listan i mitten
        private void Display(Car c)
        {
            textBox1.Text = "Make: " + c.Make;
            textBox2.Text = "Model: " + c.Model;
            textBox3.Text = "Color: " + c.Color;
            textBox4.Text = "Milage: " + c.Milage;
        }

    }

}
