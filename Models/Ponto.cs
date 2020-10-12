using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace projeto_api.Models
{
    public class Ponto
    {
        public long Id { get; set; }
        public DateTime Horario { get; set; }
        public virtual List<Solicitacao> Solicitacoes { get; set; }
        public Boolean IsAusencia { get; set; }
        public long UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

    }
}
