using Tag_Go.DAL.Entities;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Models;

namespace Tag_Go.API.Tools
{
    public static class Mappers
    {
        public static Activity ActivityToDal(this ActivityRegisterForm arf)
        {
            return new Activity
            {
                ActivityName = arf.ActivityName,
                ActivityAddress = arf.ActivityAddress,
                ActivityDescription = arf.ActivityDescription,
                ComplementareInformation = arf.ComplementareInformation,
                PosLat = arf.PosLat,
                PosLong = arf.PosLong,
                Organisateur_Id = arf.Organisateur_Id,
            };
        }
        public static Avatar AvatarToDal(this AvatarRegisterForm avrf)
        {
            return new Avatar
            {
                AvatarName = avrf.AvatarName,
                AvatarUrl = avrf.AvatarUrl,
                Description = avrf.Description,
                NUser_Id = avrf.NUser_Id,
            };
        }
        public static Chat ChatToDal(this Message ch)
        {
            return new Chat
            {
                NewMessage = ch.NewMessage,
                Author = ch.Author,
                Evenement_Id = ch.Evenement_Id,
            };
        }
        public static Icon IconToDal(this IconRegisterForm icon)
        {
            return new Icon
            {
                IconName = icon.IconName,
                IconUrl = icon.IconUrl,
                IconDescription = icon.IconDescription,
            };
        }
        public static MediaItem MediaItemToDal(this MediaItemRegisterForm mirf)
        {
            return new MediaItem
            {
                MediaType = mirf.MediaType,
                UrlItem = mirf.UrlItem,
                Description = mirf.Description,
            };
        }
        public static Person PersonToDal(this PersonRegisterForm person)
        {
            return new Person
            {
                Lastname = person.Lastname,
                Firstname = person.Firstname,
                Email = person.Email,
                Address_Street = person.Address_Street,
                Address_Nbr = person.Address_Nbr,
                PostalCode = person.PostalCode,
                Address_City = person.Address_City,
                Address_Country = person.Address_Country,
                Telephone = person.Telephone,
                Gsm = person.Gsm,
            };
        }
        public static Map MapToDal(this MapRegisterForm map)
        {
            return new Map
            {
                DateCreation = map.DateCreation,
                MapUrl = map.MapUrl,
                Description = map.Description,
            };
        }
        public static NUser NUserToDal(this NUserRegisterForm nser)
        {
            return new NUser
            {
                Email = nser.Email,
                Pwd = nser.Pwd,
                Person_Id = nser.Person_Id,
                Role_Id = nser.Role_Id,
            };
        }
        public static Organisateur OrganisateurToDal(this OrganisateurRegisterForm orf)
        {
            return new Organisateur
            {
                CompanyName = orf.CompanyName,
                BusinessNumber = orf.BusinessNumber,
                NUser_Id = orf.NUser_Id,
                Point = orf.Point,
            };
        }
        public static Bonus BonusToDal(this BonusRegisterForm bonus)
        {
            return new Bonus
            {
                BonusType = bonus.BonusType,
                BonusDescription = bonus.BonusDescription,
                Application = bonus.Application,
                Granted = bonus.Granted,
            };
        }
        public static Evenement EvenementToDal(this  EvenementRegisterForm erf) 
        {
            return new Evenement
            {
                EvenementName = erf.EvenementName,
                EvenementDescription = erf.EvenementDecription,
                PosLat = erf.PosLat,
                PosLong = erf.PosLong,
                Positif = erf.Positif,
            };
        }
        public static Recompense RecompenseToDal( this RecompenseRegisterForm rrf)
        {
            return new Recompense
            {
                Definition = rrf.Definition,
                Point = rrf.Point,
                Implication = rrf.Implacation,
                Granted = rrf.Granted,
            };
        }
        public static Vote VoteToDal( this VoteRegisterForm vrf)
        {
            return new Vote
            {
                Evenement_Id = vrf.Evenement_Id,
                FunOrNot = vrf.FunOrNot,
                Comment = vrf.Comment,
            };
        }
    }
}
