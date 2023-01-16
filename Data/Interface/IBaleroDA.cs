using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace Data.Interface
{
    public interface IBaleroDA
    {
        Task<IQueryable<Balero>> Obtener();
        Task<IQueryable<Balero>> Obtenerpro(string valorbuscado);

        Task<GE::Balero> getBalerobyid(int idBalero);
        Task<string> Save(GE::Balero balero);
        Task<string> RemoveBalero(int idBalero);

    }
}
