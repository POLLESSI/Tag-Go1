namespace Tag_Go.API.Dtos
{
    public class ActivityDTO
    {
        public string? ActivityName { get; set; }
        public string? ActivityAddress { get; set; }
        public string? ActivityDescription { get; set; }
        public string? ComplementareInformation { get; set; }
        public string? Poslat { get; set; }
        public string? PosLong { get; set; }
        public int Organisateur_Id { get; set; }
        public bool Active { get; set; }
    }
}
