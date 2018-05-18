using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPizza.Models.Repository
{
    public interface IRepositoryPizza
    {
        IEnumerable<Pizza> GetPizzasByPage(int currentPage);
        Pizza GetPizzaWithCategory(short id);
    }

}
