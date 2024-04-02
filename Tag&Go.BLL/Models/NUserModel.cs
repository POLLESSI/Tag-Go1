
namespace Tag_Go.BLL.Models
{
    public class NUserModel
    {
        public Guid NUser_Id { get; set; }
        public string? Email { get; set; }
        public string? Pwd { get; set; }
        public Guid SecurityStamp { get; set; }
        public int Person_Id { get; set; }
        public string? Role_Id { get; set; }
    }
}
