using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TanteEmmaBurger.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public String Meal { get; set; }
        public double Price { get; set; }
    }
}
