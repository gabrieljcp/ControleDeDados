using Microsoft.VisualBasic;

namespace APITeste.Models
{
    public class Consultas
    {
        public int Id { get; set; }
        public string NomePaciente { get; set; }

        public string NomeTutor { get; set; }

        public string NomeMedico { get; set; }

        public string HorarioConsulta { get; set; }

        public string DataConsulta { get; set; }

        public string NomeEspecialidade { get; set; }
    }
}