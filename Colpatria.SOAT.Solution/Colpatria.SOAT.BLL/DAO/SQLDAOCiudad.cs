

using Colpatria.SOAT.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colpatria.SOAT.BLL
{
    public class SQLDAOCiudad : ICiudadRepository
    {
        private IApplicationDbContext _dbcontext;
        public SQLDAOCiudad(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Create(Ciudades city)
        {
            _dbcontext.Ciudades.Add(city);
            await _dbcontext.SaveChanges();
            return city.Id;
        }
        public async Task<List<Ciudades>> GetAll()
        {
            List<Ciudades> lstCiudades = new List<Ciudades>();
            try
            {
                lstCiudades = await _dbcontext.Ciudades.ToListAsync<Ciudades>();
            } 
            catch(Exception ex)
            {
                return lstCiudades;
            }
            return lstCiudades;
        }
        public async Task<Ciudades> GetById(int id)
        {
            var city = await _dbcontext.Ciudades.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return city;
        }
        public async Task<string> Update(int id, Ciudades city)
        {
            var cityeeupt = await _dbcontext.Ciudades.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (cityeeupt == null) return "Ciudad no existe";
            cityeeupt.Nombre = city.Nombre;
            await _dbcontext.SaveChanges();
            return "Ciudad modificada exitosamente";
        }
        public async Task<string> Delete(int id)
        {
            var cityeedel = _dbcontext.Ciudades.Where(empid => empid.Id == id).FirstOrDefault();
            if (cityeedel == null) return "Ciudad no existe";
            _dbcontext.Ciudades.Remove(cityeedel);
            await _dbcontext.SaveChanges();
            return "Ciudad eliminada exitosamente";
        }
    }

}
