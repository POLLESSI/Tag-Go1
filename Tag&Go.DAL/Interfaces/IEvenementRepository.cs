using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Evenement;

namespace Tag_Go.DAL.Interfaces
{
    public interface IEvenementRepository
    {
        bool Create(Evenement evenement);
        void CreateEvenement(Evenement evenement);
        IEnumerable<Evenement?> GetAll();
        Evenement? GetById(int evenement_Id);
        Evenement? Delete(int evenement_Id);
        Evenement? Update(int evenement_Id, DateTime evenementDate, string evenementDescription, string posLat, string posLong, string positif, int organisateur_Id, int icon_Id, int recompense_Id, int bonus_Id, int mediaItem_Id);
    }
}
