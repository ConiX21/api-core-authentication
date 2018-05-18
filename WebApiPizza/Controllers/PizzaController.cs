using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiPizza.Models;
using WebApiPizza.Models.Repository;

namespace WebApiPizza.Controllers
{
    [Produces("application/json")]
    [Route("api/Pizza")]
    public class PizzaController : Controller
    {
        public readonly RepositoryPizza repositoryPizza;

        public PizzaController(IRepository<Pizza> repositoryPizza)
        {
            this.repositoryPizza = repositoryPizza as RepositoryPizza;
        }

        public IEnumerable<Pizza> Get()
        {
            return this.repositoryPizza.Read();
        }

        [HttpPost]
        public ObjectResult Create([FromBody]Pizza pizza)
        {
            
            try
            {                             
                if (ModelState.IsValid)
                {
                    this.repositoryPizza.Create(pizza);
                }
                else
                {
                    //ModelState.e
                    throw new Exception("Immpossible d'ajouter la pizza");
                }

                return Ok(pizza);

            }
            catch (Exception exc)
            {
                return Ok(new { Message = exc.Message, Pizza = pizza });
            }
        }


        [HttpGet("count")]
        public int Count()
        {
            var result = ((double)(this.repositoryPizza.Read().Count()) / 3);
            return (int)Math.Round(result);
        }

        [HttpGet("{current}")]
        public IEnumerable<Pizza> Get(int current)
        {
            return this.repositoryPizza.GetPizzasByPage(current);
        }

        [HttpGet("detail/{id}")]
        public Pizza Detail(byte id)
        {
            return this.repositoryPizza.GetPizzaWithCategory(id);
        }
    }
}