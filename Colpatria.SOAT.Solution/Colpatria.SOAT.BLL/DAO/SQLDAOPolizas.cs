

using Colpatria.SOAT.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Colpatria.SOAT.BLL
{
    public class SQLDAOPoliza : IPolizaRepository
    {



        private IApplicationDbContext _dbcontext;
        public SQLDAOPoliza(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<string> Create(PolizaTomadorViewModel poliza)
        {
            bool allowFecha = validateFechas(poliza);
            if(allowFecha)
            {
                bool isAllowCity = validateParametro(poliza);
                if (!isAllowCity)
                {
                    bool existUser = validateUser(poliza);
                    if (!existUser)
                    {
                        Tomador oTomador = setToTomador(poliza);
                        _dbcontext.Tomador.Add(oTomador);
                        await _dbcontext.SaveChanges();
                        poliza.IdTomador = oTomador.Id;
                        Polizas oPoliza = setToPoliza(poliza);
                        _dbcontext.Polizas.Add(oPoliza);
                        await _dbcontext.SaveChanges();
                        return "Creada Exitosamente";
                    }
                    else
                    {
                        Tomador oTomador = getUser(poliza);
                        poliza.IdTomador = oTomador.Id;
                        Polizas oPoliza = setToPoliza(poliza);
                        _dbcontext.Polizas.Add(oPoliza);
                        await _dbcontext.SaveChanges();
                        return "Creada Exitosamente";
                    }
                }
                else
                {
                    return "Esta Ciudad no tiene permitido vender polizas";
                }
            } else
            {
                return "Supero la fecha de vencimiento";
            }
        }

        private bool validateFechas(PolizaTomadorViewModel poliza)
        {
            return DateTime.Now < poliza.FechaVencimiento ? true : false;
        }

        private bool validateParametro(PolizaTomadorViewModel poliza)
        {
            Parametros oParametro = _dbcontext.Parametros.Where(x => x.Id == 1).FirstOrDefault();
            bool isAllowCity = oParametro.Valor.Contains(poliza.IdCiudad.ToString());
            return isAllowCity;
        }

        private bool validateUser(PolizaTomadorViewModel poliza)
        {
            Tomador oTomador = _dbcontext.Tomador.Where(x => x.Documento == poliza.Documento).FirstOrDefault();
            return oTomador != null ? true : false; 
        }

        private Tomador getUser(PolizaTomadorViewModel poliza)
        {
            Tomador oTomador = _dbcontext.Tomador.Where(x => x.Documento == poliza.Documento).FirstOrDefault();
            return oTomador;
        }

        private bool validatePoliza(PolizaTomadorViewModel poliza)
        {
            Tomador oTomador = _dbcontext.Tomador.Where(x => x.Documento == poliza.Documento).FirstOrDefault();
            Polizas oPoliza = _dbcontext.Polizas.Where(x => x.IdTomador == oTomador.Id && x.Estado == true).FirstOrDefault();
            if (oPoliza.FechaVencimiento >= poliza.FechaInicio)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<Polizas>> GetAll()
        {
            List<Polizas> lstPolizas = new List<Polizas>();
            try
            {
                lstPolizas = await _dbcontext.Polizas.ToListAsync<Polizas>();
            }
            catch (Exception ex)
            {
                return lstPolizas;
            }
            return lstPolizas;
        }
        public async Task<Polizas> GetById(int id)
        {
            var city = await _dbcontext.Polizas.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return city;
        }
        public async Task<string> Update(int id, Polizas poliza)
        {
            var polizaupt = await _dbcontext.Polizas.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (polizaupt == null) return "Poliza no existe";
            polizaupt.FechaInicio = poliza.FechaInicio;
            polizaupt.FechaFin = poliza.FechaFin;
            polizaupt.FechaVencimiento = poliza.FechaVencimiento;
            polizaupt.IdCiudad = poliza.IdCiudad;
            polizaupt.IdTomador = poliza.IdTomador;
            polizaupt.Estado = poliza.Estado;
            await _dbcontext.SaveChanges();
            return "Poliza modificada exitosamente";
        }
        public async Task<string> Delete(int id)
        {
            var cityeedel = _dbcontext.Polizas.Where(empid => empid.Id == id).FirstOrDefault();
            if (cityeedel == null) return "Poliza no existe";
            _dbcontext.Polizas.Remove(cityeedel);
            await _dbcontext.SaveChanges();
            return "Poliza eliminada exitosamente";
        }


        public async Task<PolizaTomadorViewModel> GetPolizaTomador(string placa)
        {
            PolizaTomadorViewModel oPolizaTomadorVM = new PolizaTomadorViewModel();
            Ciudades oPoliza = new Ciudades();
            var oPoliza2 = _dbcontext.Polizas.Where(x => x.PlacaAutomotor == placa).OrderByDescending(y => y.FechaFin).FirstOrDefault();
            if (oPoliza2 != null)
            {
                oPolizaTomadorVM = setPoliza(oPoliza2);
            }
            return oPolizaTomadorVM;
        }

        private PolizaTomadorViewModel setPoliza(Polizas oPoliza)
        {
            var oTomador = _dbcontext.Tomador.Where(x => x.Id == oPoliza.IdTomador).FirstOrDefault();
            var oCiudad = _dbcontext.Ciudades.Where(x => x.Id == oPoliza.IdCiudad).FirstOrDefault();
            PolizaTomadorViewModel oPolizaTomadorVM = new PolizaTomadorViewModel();
            oPolizaTomadorVM.Nombre = oTomador.Nombre;
            oPolizaTomadorVM.Apellido = oTomador.Apellido;
            oPolizaTomadorVM.Tipo = oTomador.Tipo;
            oPolizaTomadorVM.Direccion = oTomador.Direccion;
            oPolizaTomadorVM.Telefono = oTomador.Telefono;
            oPolizaTomadorVM.Documento = oTomador.Documento;
            oPolizaTomadorVM.FechaInicio = oPoliza.FechaInicio;
            oPolizaTomadorVM.FechaFin = oPoliza.FechaFin;
            oPolizaTomadorVM.FechaVencimiento = oPoliza.FechaVencimiento;
            oPolizaTomadorVM.PlacaAutomotor = oPoliza.PlacaAutomotor;
            oPolizaTomadorVM.Ciudad = oCiudad.Nombre;
            oPolizaTomadorVM.IdCiudad = oPoliza.IdCiudad;
            oPolizaTomadorVM.IdPoliza = oPoliza.Id;
            oPolizaTomadorVM.IdTomador = oPoliza.IdTomador;
            oPolizaTomadorVM.EstadoPoliza = oPoliza.Estado;
            oPolizaTomadorVM.EstadoTomador = oTomador.Estado;
            return oPolizaTomadorVM;
        }

        private Polizas setToPoliza(PolizaTomadorViewModel oPoliza)
        {
            Polizas oPolizaTomadorVM = new Polizas();
            oPolizaTomadorVM.FechaInicio = oPoliza.FechaInicio;
            oPolizaTomadorVM.FechaFin = oPoliza.FechaFin;
            oPolizaTomadorVM.FechaVencimiento = oPoliza.FechaVencimiento;
            oPolizaTomadorVM.PlacaAutomotor = oPoliza.PlacaAutomotor;
            oPolizaTomadorVM.IdCiudad = oPoliza.IdCiudad;
            oPolizaTomadorVM.IdTomador = oPoliza.IdTomador;
            oPolizaTomadorVM.Estado = true;
            return oPolizaTomadorVM;
        }

        private Tomador setToTomador(PolizaTomadorViewModel oPoliza)
        {
            Tomador oPolizaTomadorVM = new Tomador();
            oPolizaTomadorVM.Nombre = oPoliza.Nombre;
            oPolizaTomadorVM.Apellido = oPoliza.Apellido;
            oPolizaTomadorVM.Tipo = oPoliza.Tipo;
            oPolizaTomadorVM.Direccion = oPoliza.Direccion;
            oPolizaTomadorVM.Telefono = oPoliza.Telefono;
            oPolizaTomadorVM.Documento = oPoliza.Documento;
            oPolizaTomadorVM.Estado = true;
            return oPolizaTomadorVM;
        }
    }
}