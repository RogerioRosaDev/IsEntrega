using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Application
{
  public  class UsuarioViewModel
    {
        public int OidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool FlAtivo { get; set; }
        public string Token { get; set; }

        public string Login { get; set; }
        public string SenhaLogin { get; set; }
    }
}
