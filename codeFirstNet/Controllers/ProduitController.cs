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







        [HttpGet]
        public async Task<IActionResult> GetUpdate(int id)
        {
            var produit = await produitContext.produits.FirstOrDefaultAsync(p => p.id == id);
            if(produit != null)
            {
                ProduitCommand produitCommand = new ProduitCommand
                {
                    idCommand = produit.id,
                    titreCommand = produit.titre,
                    categorieCommand = produit.categorie,
                    quantiteCommand = produit.quantite,
                    descriptionCommand = produit.description,
                };

                return View(produitCommand);
            }
            return RedirectToAction("list");
        }


        [HttpPost]
        public async Task<IActionResult> GetUpdate(ProduitCommand produitCommand)
        {
            var produit = await produitContext.produits.FindAsync(produitCommand.idCommand);
            if (produit != null)
            {
                produit.titre = produitCommand.titreCommand;   
                produit.categorie = produitCommand.categorieCommand;
                produit.quantite = produitCommand.quantiteCommand;
                produit.description = produitCommand.descriptionCommand;
                await produitContext.SaveChangesAsync();
                return RedirectToAction("list");
            }
            return RedirectToAction("list");
        }



        [HttpGet]
        public async Task<IActionResult> GetDelete(int id)
        {
            var produit = await produitContext.produits.FirstOrDefaultAsync(p => p.id == id);
            if (produit != null)
            {
                return View(produit);
            }
            return RedirectToAction("list");
        }



        [HttpPost]
        public async Task<IActionResult> GetDelete(Produit produit)
        {
            var produitDelete = await produitContext.produits.FindAsync(produit.id);
            if (produitDelete != null)
            {
                produitContext.produits.Remove(produitDelete);
                await produitContext.SaveChangesAsync();
                return RedirectToAction("list");
            }
            return RedirectToAction("list");
        }

    }
}
