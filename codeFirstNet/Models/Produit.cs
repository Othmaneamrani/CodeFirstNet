using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace codeFirstNet.Models
{
    public class Produit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string titre { get; set; }

        [Required]
        public string categorie { get; set; }

        [Required]
        public int quantite { get; set; }

        [Required]
        public string description { get; set; }

    }
}
