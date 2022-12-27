using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.DAL
{
    /// <summary>
    /// Interface de polizas
    /// </summary>
    public interface IPolizaRepository
    {
        Task<string> Create(PolizaTomadorViewModel poliza);
        Task<List<Polizas>> GetAll();
        Task<Polizas> GetById(int id);
        Task<string> Update(int id, Polizas poliza);
        Task<string> Delete(int id);
        Task<PolizaTomadorViewModel> GetPolizaTomador(string placa);

    }
}
