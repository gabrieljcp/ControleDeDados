using APITeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicosController : ControllerBase
    {

        [HttpGet()]
        public IEnumerable<Medicos> Get()
        {

            return MedicosLista.ToList();
        }


        public static List<Medicos> MedicosLista = new List<Medicos>();


        [HttpPost()]
        public Medicos Post([FromBody] Medicos medicos)
        {

            MedicosLista.Add(medicos);


            return medicos;
        }
    }
}