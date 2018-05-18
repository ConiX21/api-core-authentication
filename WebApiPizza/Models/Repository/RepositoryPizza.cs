using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPizza.Models.Repository
{
    public class RepositoryPizza: Repository<Pizza>, IRepositoryPizza
    {
        public Pizza_dotNetContext Context {
            get
            {
                return Ctx as Pizza_dotNetContext;
            }
        }

        public RepositoryPizza(Pizza_dotNetContext pizzaDBContext)
            :base(pizzaDBContext)
        {
            
        }
        
        public IEnumerable<Pizza> GetPizzasByPage(int currentPage)
        {
            return Context.Pizza.Skip(currentPage * 3).Take(3);
        }

        public Pizza GetPizzaWithCategory(short id)
        {
            return Context.Pizza
                        .Include(i => i.Category)
                        .Single(p => p.IdPizza == id);
        }
    }
}
