using System;

namespace SIS_ISENTREGA.Domain
{
    public class Usuario
    {
        public int OidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool FlAtivo { get; set; }
        public string  Token{ get; set; }

    }
}
