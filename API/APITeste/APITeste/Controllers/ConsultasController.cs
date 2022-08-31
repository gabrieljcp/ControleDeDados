using APITeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultasController : ControllerBase
    {

        [HttpGet()]
        public IEnumerable<Consultas> Get()
        {

            return ConsultasLista.ToList();
        }


        public static List<Consultas> ConsultasLista = new List<Consultas>();


        [HttpPost()]
        public Consultas Post([FromBody] Consultas consultas)
        {

            ConsultasLista.Add(consultas);


            return consultas;
        }
    }
}