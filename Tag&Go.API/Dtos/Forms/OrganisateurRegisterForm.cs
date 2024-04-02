using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos.Forms
{
    public class OrganisateurRegisterForm
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Company Name : ")]
        public string? CompanyName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(16)]
        [DisplayName("BusinessNumber : ")]
        public string? BusinessNumber { get; set; }
        [Required]
        [DisplayName("Guid User : ")]
        public Guid NUser_Id { get; set; }
        [MinLength(1)]
        [MaxLength(8)]
        [DisplayName("Points : ")]
        public string? Point { get; set; }
    }
}
