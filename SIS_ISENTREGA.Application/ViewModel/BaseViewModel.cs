using System;

namespace SIS_ISENTREGA.Application
{
    public  class BaseViewModel
    {
        public int? OidMatriz { get; set; }
        public string NomeMatriz { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CEP { get; set; }
    }
}
