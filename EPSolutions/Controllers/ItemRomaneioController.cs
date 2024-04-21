using EPSolutions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EPSolutions.Controllers
{
    public class ItemRomaneioController : Controller
    {
        private readonly TreinamentoContext _dbContext;

        public ItemRomaneioController(TreinamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: ItemRomaneioController
        public ActionResult Index()
        {
            var itemsRomaneio = _dbContext.ItensRomaneio.ToList();
            return View(itemsRomaneio);
        }

        // GET: ItemRomaneioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemRomaneioController/Create
        public ActionResult Create()
        {
            ViewBag.IdRomaneio = new SelectList(_dbContext.Romaneios, "Id", "NomeCliente");
            return View();
        }

        // POST: ItemRomaneioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemRomaneioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemRomaneioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemRomaneioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemRomaneioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
