﻿using System;
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
        List<string> ColorCheck = new List<string>();

        public CarsInStock()
        {
            _cars.Add(new Car { Make = "Volvo", Model = "V70", Color = "Red", Milage = 1240 });
            _cars.Add(new Car { Make = "Audi", Model = "A3", Color = "White", Milage = 34000 });
            _cars.Add(new Car { Make = "Volvo", Model = "V70", Color = "Black", Milage = 505 });
            _cars.Add(new Car { Make = "BMW", Model = "750", Color = "Green", Milage = 28500 });
            _cars.Add(new Car { Make = "Skoda", Model = "Octavia", Color = "Red", Milage = 820 });
            _cars.Add(new Car { Make = "Volvo", Model = "V60", Color = "Red", Milage = 12890 });
            _cars.Add(new Car { Make = "Audi", Model = "Q3", Color = "Black", Milage = 22300 });
            _cars.Add(new Car { Make = "BMW", Model = "328", Color = "White", Milage = 5500 });
            _cars.Add(new Car { Make = "Volvo", Model = "V60", Color = "Black", Milage = 1402 });
            _cars.Add(new Car { Make = "Opel", Model = "Ascona", Color = "Black", Milage = 6750 });

            InitializeComponent();

            //Set-up form
            button1.Text = "Display milage";
            Text = "Cars in stock";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            button1.Click += new EventHandler((sender, e) =>
            {
                DisplayMilage();
            });



            foreach (Car c in _cars)
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
                Display(c);
            });

            comboBox1.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Car c = (Car)comboBox1.SelectedItem;
                MessageBox.Show(string.Format("We have {0} cars with {1} color in stock", ColorCount(c), c.Color));
            });
        }

        private void DisplayMilage()
        {
            MessageBox.Show(string.Format("We have {0} cars in stock, average milage is {1} km, " +
                "the lowest milage is {2} km and the highest is {3} km ",
                _cars.Count(),
                _cars.Average(x => x.Milage),
                _cars.Min(x => x.Milage),
                _cars.Max(x => x.Milage)));
        }

        private int ColorCount (Car c)
        {
            int answer;
            string color = c.Color;
            answer = _cars.Count(x => x.Color == string.Format("{0}", color));
            return answer;
        }


        

        private void Display(Car c)
        {
            textBox1.Text = "Märke: " + c.Make;
            textBox2.Text = "Modell: " + c.Model;
            textBox3.Text = "Färg: " + c.Color;
            textBox4.Text = "Antal mil: " + c.Milage;
        }
    }
}
