

using Colpatria.SOAT.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colpatria.SOAT.BLL
{
    public class SQLDAOParametro : IParametroRepository
    {

        

        private IApplicationDbContext _dbcontext;
        public SQLDAOParametro(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Create(Parametros parametro)
        {
            _dbcontext.Parametros.Add(parametro);
            await _dbcontext.SaveChanges();
            return parametro.Id;
        }
        public async Task<List<Parametros>> GetAll()
        {
            List<Parametros> lstParametros = new List<Parametros>();
            try
            {
                lstParametros = await _dbcontext.Parametros.ToListAsync<Parametros>();
            } 
            catch(Exception ex)
            {
                return lstParametros;
            }
            return lstParametros;
        }
        public async Task<Parametros> GetById(int id)
        {
            var parametro = await _dbcontext.Parametros.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return parametro;
        }
        public async Task<string> Update(int id, Parametros parametro)
        {
            var parametroeeupt = await _dbcontext.Parametros.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (parametroeeupt == null) return "Parametro no existe";
            parametroeeupt.Nombre = parametro.Nombre;
            parametroeeupt.Valor = parametro.Valor;
            parametroeeupt.Tipo = parametro.Tipo;
            await _dbcontext.SaveChanges();
            return "Parametro modificada exitosamente";
        }
        public async Task<string> Delete(int id)
        {
            var parametroeedel = _dbcontext.Parametros.Where(empid => empid.Id == id).FirstOrDefault();
            if (parametroeedel == null) return "Parametro no existe";
            _dbcontext.Parametros.Remove(parametroeedel);
            await _dbcontext.SaveChanges();
            return "Parametro eliminada exitosamente";
        }
    }

}
