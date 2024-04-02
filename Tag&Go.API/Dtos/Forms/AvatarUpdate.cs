using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos.Forms
{
    public class AvatarUpdate
    {
        [Required]
        [DisplayName("Id Avatar : ")]
        public int Avatar_Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Avatar name : ")]
        public string? AvatarName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(2048)]
        [DisplayName("Avatar Url : ")]
        public string? AvatarUrl { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(2048)]
        [DisplayName("Description : ")]
        public string? Description { get; set; }
        [Required]
        [DisplayName("Guid NUser : ")]
        public Guid NUser_Id { get; set; }
    }
}
