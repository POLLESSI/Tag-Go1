namespace Tag_Go.API.Dtos
{
    public class VoteDTO
    {
        public int Evenement_Id { get; set; }
        public string? FunOrNot { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
    }
}
