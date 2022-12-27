

using Colpatria.SOAT.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colpatria.SOAT.BLL
{
    public class SQLDAOTomador : ITomadorRepository
    {

        

        private IApplicationDbContext _dbcontext;
        public SQLDAOTomador(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Create(Tomador tomador)
        {
            _dbcontext.Tomador.Add(tomador);
            await _dbcontext.SaveChanges();
            return tomador.Id;
        }
        public async Task<List<Tomador>> GetAll()
        {
            List<Tomador> lstTomador = new List<Tomador>();
            try
            {
                lstTomador = await _dbcontext.Tomador.ToListAsync<Tomador>();
            } 
            catch(Exception ex)
            {
                return lstTomador;
            }
            return lstTomador;
        }
        public async Task<Tomador> GetById(int id)
        {
            var tomador = await _dbcontext.Tomador.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return tomador;
        }
        public async Task<string> Update(int id, Tomador tomador)
        {
            var tomadoreeupt = await _dbcontext.Tomador.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (tomadoreeupt == null) return "Tomador no existe";
            tomadoreeupt.Nombre = tomador.Nombre;
            tomadoreeupt.Apellido = tomador.Apellido;
            tomadoreeupt.Direccion = tomador.Direccion;
            tomadoreeupt.Telefono = tomador.Telefono;
            tomadoreeupt.Documento = tomador.Documento;
            tomadoreeupt.Tipo = tomador.Tipo;
            tomadoreeupt.Estado = tomador.Estado;
            await _dbcontext.SaveChanges();
            return "Tomador modificada exitosamente";
        }
        public async Task<string> Delete(int id)
        {
            var tomadoreedel = _dbcontext.Tomador.Where(empid => empid.Id == id).FirstOrDefault();
            if (tomadoreedel == null) return "Tomador no existe";
            _dbcontext.Tomador.Remove(tomadoreedel);
            await _dbcontext.SaveChanges();
            return "Tomador eliminada exitosamente";
        }
    }

}
