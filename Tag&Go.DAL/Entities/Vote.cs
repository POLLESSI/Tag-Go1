
namespace Tag_Go.DAL.Entities
{
    public class Vote
    {
        public int Vote_Id { get; set; }
        public int Evenement_Id { get; set; }
        public bool FunOrNot { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
    }
}
