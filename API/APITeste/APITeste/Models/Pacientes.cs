using Microsoft.VisualBasic;

namespace APITeste.Models
{
    public class Pacientes
    {
        public int Id { get; set; }
        public string nomePaciente { get; set; }

        public string especie { get; set; }

        public string raca { get; set; }

        public string castrado { get; set; }

        public string corPelo { get; set; }

        public string dataNascimento { get; set; }
    }
}