using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tag_Go.API.Dtos.Forms
{
    public class AvatarRegisterForm
    {
        public string? AvatarName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public Guid NUser_Id { get; set; }
    }
}
