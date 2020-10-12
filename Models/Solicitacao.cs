using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace projeto_api.Models
{
    public class Solicitacao
    {
        public long Id { get; set; }
        public bool IsAplicado { get; set; }
        public DateTime NovoHorario { get; set; }
        public long PontoId { get; set; }
        [JsonIgnore]
        public virtual Ponto Ponto { get; set; }
    }
}
