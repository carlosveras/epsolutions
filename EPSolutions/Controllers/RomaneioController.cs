using Azure;
using EPSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EPSolutions.Controllers
{
    public class RomaneioController : Controller
    {
        private readonly ILogger<RomaneioController> _logger;
        private readonly TreinamentoContext _dbContext;

        public RomaneioController(ILogger<RomaneioController> logger, TreinamentoContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> Entregar(int id)
        {
            TempData["IdRomaneio"] = id.ToString();
            var itensRomaneio = _dbContext.ItensRomaneio.Where(x => x.IdRomaneio == id).ToList();
            return PartialView("_ItensRomaneioPartial", itensRomaneio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entregar ([FromBody] List<ItensRomaneio> itensRomaneio)
        {

            var selectedCourses = itensRomaneio.Where(x => x.Entregue == true).ToList();

            var message = "Tag cadastrada com sucesso";
            var titulo = "Cadastro";

            ViewData["Acao"] = titulo;
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
