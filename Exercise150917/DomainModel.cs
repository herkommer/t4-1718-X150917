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
        public string Milage { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Make, Model);
        }
    }

    public class Stock
    {
        private List<Car> _cars;

        public Stock()
        {
            _cars = new List<Car>();

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
