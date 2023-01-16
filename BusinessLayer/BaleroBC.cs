using BusinessLayer.Interface;
using Data.Interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace BusinessLayer
{
    public class BaleroBC:IBaleroBC
    {
        private readonly IBaleroDA baleroDA;

        public BaleroBC(IBaleroDA baleroDA)
        {
            this.baleroDA = baleroDA;
        }

        public async Task<GE::Balero> getBalerobyid(int idBalero)
        {
            return await this.baleroDA.getBalerobyid(idBalero);
        }

        public async Task<IQueryable<Balero>> Obtener()
        {
           return await this.baleroDA.Obtener();
        }

        public async Task<IQueryable<Balero>> Obtenerpro(string valorbuscado)
        {
            return await this.baleroDA.Obtenerpro(valorbuscado);
        }

        public async Task<string> RemoveBalero(int idBalero)
        {
            return await this.baleroDA.RemoveBalero(idBalero);
        }

        public async Task<string> Save(GE::Balero balero)
        {
            return await this.baleroDA.Save(balero);
        }
    }
}
