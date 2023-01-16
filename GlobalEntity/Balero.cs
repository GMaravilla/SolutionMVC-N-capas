using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity
{
    public class Balero
    {
        public int IdBaleros { get; set; }

        public string Marca { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public decimal Precio { get; set; }

        public DateTime? FechaCreate { get; set; }
    }
}
