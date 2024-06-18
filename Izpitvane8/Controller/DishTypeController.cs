using Izpitvane8.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane8.Controller
{
    public class DishTypeController
    {
        private DishDbContext _dishDbContext = new DishDbContext();
        public List<DishType> GetAllDishType()
        {
            return _dishDbContext.DishType.ToList();
        }
        public string GetDishTypeById(int id)
        {
            return _dishDbContext.DishType.Find(id).Type;
        }
    }
}
