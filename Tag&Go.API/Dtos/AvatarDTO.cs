﻿namespace Tag_Go.API.Dtos
{
    public class AvatarDTO
    {
        public string? AvatarName { get; set; }
        public string? Decription { get; set; }
        public Guid NUser_Id { get; set; }
        public bool Active { get; set; }
    }
}
