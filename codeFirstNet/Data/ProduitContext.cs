using Microsoft.EntityFrameworkCore;
using codeFirstNet.Models;

namespace codeFirstNet.Data
{
    public class ProduitContext : DbContext
    {
        public ProduitContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produit> produits { get; set; }
    }
}
