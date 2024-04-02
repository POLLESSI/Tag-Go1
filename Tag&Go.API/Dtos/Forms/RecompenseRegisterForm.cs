using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tag_Go.API.Dtos.Forms
{
    public class RecompenseRegisterForm
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Definition : ")]
        public string? Definition { get; set; }
        [Required]
        [MinLength(1)]
        [DisplayName("Point : ")]
        public string? Point { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Implication : ")]
        public string? Implacation { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(4)]
        [DisplayName("Granted ? : ")]
        public string? Granted { get; set; }
    }
}
