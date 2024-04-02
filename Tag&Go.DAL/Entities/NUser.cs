
namespace Tag_Go.DAL.Entities
{
    public class NUser
    {
        public Guid NUser_Id { get; set; }
        public string? Email { get; set; }
        public string? Pwd { get; set; } 
        public int Person_Id { get; set; }
        public string? Role_Id { get; set; }
        public int Avatar_Id { get; set; }
        public string? Point { get; set; }
        public bool Active { get; set; }
    }
}
