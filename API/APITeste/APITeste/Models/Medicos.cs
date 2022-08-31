using Microsoft.VisualBasic;

namespace APITeste.Models
{
    public class Medicos
    {
        public int Id { get; set; }
        public string nomeMedico { get; set; }

        public string crm { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }        

        public string nomeEspecialidade { get; set; }
    }
}