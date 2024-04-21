using EPSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EPSolutions.Controllers
{
    public class ItensRomaneioController : Controller
    {
        private readonly ILogger<ItensRomaneioController> _logger;
        private readonly TreinamentoContext _dbContext;

        public ItensRomaneioController(ILogger<ItensRomaneioController> logger, TreinamentoContext dbContext)
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
        public IActionResult Pesquisar(int id)
        {
            TempData["IdRomaneio"] = id.ToString();
            List<ItensRomaneio> listRomaneios = [];

            var romaneio = _dbContext.Romaneios.Find(id);

            if (romaneio != null)
                listRomaneios = _dbContext.ItensRomaneio.Where(x => x.IdRomaneio == id && x.Entregue == false).ToList();

            return View("Index", listRomaneios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entregar(IFormCollection itensRomaneios)
        {
            var romaneiosSelecionados = itensRomaneios.Where(c => c.Key == "ItensEntregues").ToList().Select(c => c.Value).ToList();

            var idRomaneio = Convert.ToInt32(itensRomaneios.FirstOrDefault(c => c.Key == "IdRomaneio").Value);

            foreach (var item in romaneiosSelecionados[0].ToString().Split(","))
            {
                var itemParaAtualizar = await _dbContext.ItensRomaneio.FindAsync(Convert.ToInt32(item), idRomaneio);

                if (itemParaAtualizar != null)
                {
                    itemParaAtualizar.Entregue = true;
                    await _dbContext.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
