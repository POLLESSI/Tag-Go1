using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos.Forms
{
    public class MediaItemUpdate
    {
        [Required]
        [DisplayName("Id Media Item : ")]
        public int Media_Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Media Type : ")]
        public string? MediaType { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(2048)]
        public string? UrlItem { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        [DisplayName("Description : ")]
        public string? Description { get; set; }
    }
}
