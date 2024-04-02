namespace Tag_Go.API.Dtos
{
    public class EvenementDTO
    {
        public DateTime EvenementDate { get; set; }
        public string? EvenementName { get; set; }
        public string? EvenementDescription { get; set; }
        public string? PosLat { get; set; }
        public string? PosLong { get; set; }
        public string? Positif { get; set; }
        public int Organisateur_Id { get; set; }
        public int Icon_Id { get; set; }
        public int Recompense_Id { get; set; }
        public int Bonus_Id { get; set; }
        public int MediaItem_Id { get; set; }
        public bool Active { get; set; }
    }
}
