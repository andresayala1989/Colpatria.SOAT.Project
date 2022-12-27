using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    /// <summary>
    /// Interface de Tomador
    /// </summary>
    public interface ITomadorRepository
    {
        Task<int> Create(Tomador tomador);
        Task<List<Tomador>> GetAll();
        Task<Tomador> GetById(int id);
        Task<string> Update(int id, Tomador tomador);
        Task<string> Delete(int id);
    }
}
