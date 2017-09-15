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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //Set-up form
            btnOpenCarsInStock.Text = "Show Cars in Stock";


            //EventHandlers
            btnOpenCarsInStock.Click += new EventHandler((sender, e) =>
            {
                CarsInStock frmCarsInStock = new CarsInStock();
                frmCarsInStock.ShowDialog();
            });
        }
    }
}
