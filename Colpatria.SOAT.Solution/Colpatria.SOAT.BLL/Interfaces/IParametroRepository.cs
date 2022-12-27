using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    /// <summary>
    /// Interface de Parametros
    /// </summary>
    public interface IParametroRepository
    {
        Task<int> Create(Parametros parametro);
        Task<List<Parametros>> GetAll();
        Task<Parametros> GetById(int id);
        Task<string> Update(int id, Parametros parametro);
        Task<string> Delete(int id);
    }
}
