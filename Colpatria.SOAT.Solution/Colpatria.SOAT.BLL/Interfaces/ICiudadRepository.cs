using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    /// <summary>
    /// Interface de ciudad
    /// </summary>
    public interface ICiudadRepository
    {
        Task<int> Create(Ciudades employee);
        Task<List<Ciudades>> GetAll();
        Task<Ciudades> GetById(int id);
        Task<string> Update(int id, Ciudades employee);
        Task<string> Delete(int id);
    }
}
