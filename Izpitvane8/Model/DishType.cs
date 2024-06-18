using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane8.Model
{
    public class DishType
    {
        public int Id { get; set; } 
        public string Type {  get; set; }
        public ICollection<Dishes>Dishes { get; set; }
    }
}
