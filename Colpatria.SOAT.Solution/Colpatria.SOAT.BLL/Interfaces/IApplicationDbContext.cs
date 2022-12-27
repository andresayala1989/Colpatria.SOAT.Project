using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    /// <summary>
    /// Interfaz que agrega los modelos que se conectaran a las BDs
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<Ciudades> Ciudades { get; set; }
        DbSet<Parametros> Parametros { get; set; }
        DbSet<Polizas> Polizas { get; set; }
        DbSet<Tomador> Tomador { get; set; }
        Task<int> SaveChanges();
    }
}
