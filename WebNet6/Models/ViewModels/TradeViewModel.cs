using System.ComponentModel.DataAnnotations;

namespace WebNet6.Models.ViewModels
{
    public class TradeViewModel
    {
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int TradeTypeId { get; set; }
    }
}
