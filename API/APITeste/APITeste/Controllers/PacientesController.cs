using APITeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {

        [HttpGet()]
        public IEnumerable<Pacientes> Get()
        {

            return PacientesLista.ToList();
        }


        public static List<Pacientes> PacientesLista = new List<Pacientes>();


        [HttpPost()]
        public Pacientes Post([FromBody] Pacientes pacientes)
        {

            PacientesLista.Add(pacientes);


            return pacientes;
        }
    }
}