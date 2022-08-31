using APITeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecialidadesController : ControllerBase
    {

        [HttpGet()]
        public IEnumerable<Especialidades> Get()
        {

            return EspecialidadesLista.ToList();
        }


        public static List<Especialidades> EspecialidadesLista = new List<Especialidades>();


        [HttpPost()]
        public Especialidades Post([FromBody] Especialidades especialidades)
        {

            EspecialidadesLista.Add(especialidades);


            return especialidades;
        }
    }
}