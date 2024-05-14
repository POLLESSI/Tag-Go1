namespace Tag_Go.API.Dtos
{
    public class NEvenementDTO
    {
        public DateTime NEvenementDate { get; set; }
        public string? NEvenementName { get; set; }
        public string? NEvenementDescription { get; set; }
        public string? PosLat { get; set; }
        public string? PosLong { get; set; }
        public string? Positif { get; set; }
        public int Organisateur_Id { get; set; }
        public int NIcon_Id { get; set; }
        public int Recompense_Id { get; set; }
        public int Bonus_Id { get; set; }
        public int MediaItem_Id { get; set; }
        public bool Active { get; set; }
    }
}
