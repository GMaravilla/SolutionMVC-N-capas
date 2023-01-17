using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using GE = GlobalEntity;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Data.Models;

namespace AppWeb.Controllers
{
    public class BaleroController : Controller
    {

        private readonly IBaleroBC baleroBC;
        
        public BaleroController(IBaleroBC baleroBC)
        {
            this.baleroBC = baleroBC;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new GE.Balero());
        }

        public async Task<IActionResult> Edit(int idBalero)
        {
            GE::Balero balero = await this.baleroBC.getBalerobyid(Convert.ToInt32(idBalero));
            return View("Create", balero);
        }

        public async Task<IActionResult> Save(GE::Balero balero)
        {
            string Response = await this.baleroBC.Save(balero);
            return Json(Response);
        }

        public async Task<IActionResult> Remove(string idBalero)
        {
            string Response = await this.baleroBC.RemoveBalero(Convert.ToInt32(idBalero));
            return Json(Response);
        }

        public async Task<IActionResult> GetAll(string valorbuscado)
        {
            int Nrorepeticion = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");
            int Cantidadderegistros = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int Omitirregistros = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            valorbuscado = Request.Form["search[value]"].FirstOrDefault() ?? "";
            List<Balero> lista = new List<Balero>();

            IQueryable<Balero> query = await this.baleroBC.Obtener();
            int totalregistros = query.Count();

            int totalregistrosfiltrados = query.Count();



            lista = query.Skip(Omitirregistros).Take(Cantidadderegistros).ToList();



            return Json(new
            {
                draw = Nrorepeticion,
                recordsTotal = totalregistros,
                recordsFiltered = totalregistrosfiltrados,
                data = lista
            });
        }
    }
}
