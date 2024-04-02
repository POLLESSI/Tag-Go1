using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos
{
    public class Message
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Author : ")]
        public string? Author { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Message : ")]
        public string? NewMessage { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.UtcNow;
        [Required]
        [DisplayName("Event Id : ")]
        public int Evenement_Id { get; set; }
        [DisplayName("Is Private? : ")]
        public string? IsPrivate { get; set; } = "No";
    }
}
