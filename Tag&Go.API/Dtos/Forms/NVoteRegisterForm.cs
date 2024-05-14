using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos.Forms
{
    public class NVoteRegisterForm
    {
        [Required]
        [DisplayName("Id Event : ")]
        public int NEvenement_Id { get; set; }
        [Required]
        [DisplayName("Fun ? Y for Yes, N for Not : ")]
        public bool FunOrNot { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(128)]
        [DisplayName("Comments : ")]
        public string? Comment { get; set; }
    }
}
