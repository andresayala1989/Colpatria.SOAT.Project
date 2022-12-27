using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    public class PolizaTomadorViewModel
    {
        public int IdPoliza { get; set; }
        public int IdTomador { get; set; }
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool EstadoTomador { get; set; }
        public string PlacaAutomotor { get; set; }
        public string Ciudad { get; set; }
        public bool EstadoPoliza { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
