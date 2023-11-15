using codeFirstNet.Data;
using codeFirstNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codeFirstNet.Controllers
{
    public class ProduitController : Controller
    {
        private ProduitContext produitContext;

        public ProduitController(ProduitContext produitContext)
        {
            this.produitContext = produitContext;
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Add(ProduitCommand produitCommand)
        {
            Produit produit = new Produit
            {
                titre = produitCommand.titreCommand,
                categorie = produitCommand.categorieCommand,
                quantite = produitCommand.quantiteCommand,
                description = produitCommand.descriptionCommand,
            };
            await produitContext.produits.AddAsync(produit);
            await produitContext.SaveChangesAsync();

            return RedirectToAction("list");
        }



        [HttpGet]
        public async Task<IActionResult> list()
        {
            var produits = await produitContext.produits.ToListAsync();
            return View(produits);
        }

    }
}
