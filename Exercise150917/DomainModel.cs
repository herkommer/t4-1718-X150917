using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise150917
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Milage { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Make, Model, Color, Milage);
        }
    }

    public class Stock
    {
        private List<Car> _cars;

        public Stock()
        {
            _cars = new List<Car>();
        }

        public List<Car> Cars
        {
            get
            {
                return _cars;
            }
        }
    }
}
