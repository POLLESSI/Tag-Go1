namespace Tag_Go.API.Models
{
    public class VoteModel
    {
        public int Vote_Id { get; set; }
        public int Evenement_Id { get; set; }
        public bool FunOrNot { get; set; }
        public string? Comment { get; set; }
    }
}
