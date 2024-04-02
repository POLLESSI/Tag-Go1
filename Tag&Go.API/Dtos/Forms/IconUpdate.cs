using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos.Forms
{
    public class IconUpdate
    {
        [Required]
        [DisplayName("Icon_Id : ")]
        public int Icon_Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Icon name : ")]
        public string? IconName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        [DisplayName("Icon Description : ")]
        public string? IconDescription { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(2048)]
        [DisplayName("Icon Url : ")]
        public string? IconUrl { get; set; }
    }
}
