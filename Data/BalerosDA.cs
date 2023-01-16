using Azure;
using Data.Interface;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace Data
{
    public class BalerosDA:IBaleroDA
    {
        private readonly MvcPruebasContext MvcContext;

        public BalerosDA(MvcPruebasContext MvcContext)
        {
            this.MvcContext = MvcContext;
        }

        public async Task<GE::Balero> getBalerobyid(int idBalero)
        {
            var _data = await this.MvcContext.Baleros.FirstOrDefaultAsync(item =>item.IdBaleros==idBalero);

            GE::Balero balero = new GE.Balero();
            if (_data!=null)
            {
                balero = (new GE.Balero
                {
                    IdBaleros= _data.IdBaleros,
                    Marca= _data.Marca,
                    Codigo= _data.Codigo,
                    Precio = _data.Precio,
                    FechaCreate= _data.FechaCreate,
                });
            }

            return balero;
        }

        public async Task<IQueryable<Balero>> Obtener()
        {
            IQueryable<Balero> queery = this.MvcContext.Baleros;
            return queery;
        }

        public async Task<IQueryable<Balero>> Obtenerpro(string valorbuscado)
        {
           IQueryable<Balero> quuery = await this.Obtener();
            quuery = (IQueryable<Balero>)quuery.Where(e => string.Concat(e.Codigo).Contains(valorbuscado)).ToListAsync();
            return quuery; 
        }

        public async Task<string> RemoveBalero(int idBalero)
        {
           var _data = await this.MvcContext.Baleros.FirstOrDefaultAsync(item => item.IdBaleros == idBalero);
            string response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.MvcContext.Baleros.Remove(_data);
                    await this.MvcContext.SaveChangesAsync();
                    response = "pass";
                }
                catch (Exception ex)
                {

                    response = ex.Message;
                }
            }
            return response;
        }

        public async Task<string> Save(GE::Balero balero)
        {
            string Response = string.Empty;

            try
            {
                if (balero.IdBaleros > 0)
                {
                    var _exist = await this.MvcContext.Baleros.FirstOrDefaultAsync(item=>item.IdBaleros== balero.IdBaleros);
                    if(_exist != null )
                    {
                        _exist.Marca= balero.Marca;
                        _exist.Codigo= balero.Codigo;
                        _exist.Precio= balero.Precio;
                        _exist.FechaCreate= balero.FechaCreate;
                    }
                }
                else
                {
                    Balero _balero = new Balero()
                    {
                        Marca= balero.Marca,
                        Codigo= balero.Codigo,
                        Precio= balero.Precio,
                        FechaCreate= balero.FechaCreate,
                    };
                    await this.MvcContext.Baleros.AddAsync(_balero);
                }
                await this.MvcContext.SaveChangesAsync();

                Response = "pass";
            }
            catch (Exception ex)
            {
                Response = ex.Message;
            }
            return Response;
        }
    }
}
