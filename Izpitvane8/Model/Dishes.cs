using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane8.Model
{
   public class Dishes
   {
        public int Id { get; set; } 
        public string NameDish { get; set; }
        public string Description { get; set; }
        public int Price {  get; set; } 
        public double Weight {  get; set; }

        public int DishTypeID { get; set; }
        public DishType DishType { get; set; }

    }
}
