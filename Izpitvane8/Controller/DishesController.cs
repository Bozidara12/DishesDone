using Izpitvane8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane8.Controller
{
    public class DishesController
    {
        private DishDbContext _dishDbContext = new DishDbContext();
        public Dishes Get(int id)
        {
            Dishes findedDishes = _dishDbContext.Dishes.Find(id);
            if (findedDishes != null)
            {
                _dishDbContext.Entry(findedDishes).Reference(x => x.DishType).Load();
            }
            return findedDishes;
        }
        public List<Dishes> GetAll()
        {
            return _dishDbContext.Dishes.Include("DishType").ToList();
        }
        public void Create(Dishes dish)
        {
            _dishDbContext.Dishes.Add(dish);
            _dishDbContext.SaveChanges();
        }
        public void Update(int id, Dishes dish)
        {
            Dishes findedDishes = _dishDbContext.Dishes.Find(id);
            if (findedDishes == null)
            {
                return;
            }
            findedDishes.Description = dish.Description;
            findedDishes.NameDish = dish.NameDish;
            findedDishes.Price = dish.Price;
            findedDishes.Weight = dish.Weight;
            //findedDishes.DishTypeId = dish.Id;
            _dishDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Dishes findedDog = _dishDbContext.Dishes.Find(id);
            _dishDbContext.Dishes.Remove(findedDog);
            _dishDbContext.SaveChanges();
        }
    }
}
