﻿
namespace Tag_Go.DAL.Entities
{
    public class Organisateur
    {
        public int Organisateur_Id { get; set; }
        public string? CompanyName { get; set; }
        public string? BusinessNumber { get; set; }
        public Guid NUser_Id { get; set; }
        public string? Point { get; set; }
        public bool Active { get; set; }
    }
}
