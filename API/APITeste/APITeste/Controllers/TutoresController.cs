using APITeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoresController : ControllerBase
    {

        [HttpGet()]
        public IEnumerable<Tutores> Get()
        {

            return TutoresLista.ToList();
        }


        public static List<Tutores> TutoresLista = new List<Tutores>();


        [HttpPost()]
        public Tutores Post([FromBody] Tutores tutores)
        {

            TutoresLista.Add(tutores);


            return tutores;
        }
    }
}