using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    public class Polizas
    {
        public int Id { get; set; }
        public int IdTomador { get; set; }
        public int IdCiudad { get; set; }
        public string PlacaAutomotor { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Estado { get; set; }
    }
}
