using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane8.Model
{
    public class DishDbContext:DbContext
    {
        public DishDbContext():base ("DishDBContext") 
        {

        }  
        public DbSet<Dishes>Dishes { get; set; }
        public DbSet<DishType>DishType { get; set; }

    }
}
