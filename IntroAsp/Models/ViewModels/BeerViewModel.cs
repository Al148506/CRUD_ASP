using System.ComponentModel.DataAnnotations;

namespace IntroAsp.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        [Display(Name= "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public int BrandId { get; set; }
        public int BeerId { get; set; }
    }
}
