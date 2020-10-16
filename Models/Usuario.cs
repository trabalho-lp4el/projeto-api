using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_api.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Ponto> Pontos { get; set; }
        public string Matricula { get; set; }

        public string Senha { get; set; }
    }
}
