using System.ComponentModel.DataAnnotations;

namespace ConsumindoRestAPI.Models
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name ="Nome da Pessoa")]
        [StringLength(100, MinimumLength = 8)]
        public string nome { get; set; }
    }
}
