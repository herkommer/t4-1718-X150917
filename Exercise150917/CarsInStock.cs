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
            }

            //Eventhandlers
            listBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)listBox1.SelectedItem;
                Display(c);

            });



        }

        private void Display(Car c) {
            textBox1.Text = "Make: " + c.Make+".";
            textBox2.Text = "Model: " + c.Model+".";
            textBox3.Text = "Color: " + c.Color+".";
            textBox4.Text = "Milage: " + c.Milage + " Km.";
        }

    }
}
