using Tag_Go.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.NEvenement;

namespace Tag_Go.BLL.Interfaces
{
    public interface INEvenementService
    {
        bool Create(NEvenement nEvenement);
        void CreateEvenement(NEvenement nEvenement);
        IEnumerable<NEvenement?> GetAll();
        NEvenement? GetById(int nEvenement_Id);
        NEvenement? Delete(int nEvenement_Id);
        NEvenement? Update(DateTime nEvenementDate, string nEvenementName, string nEvenementDescription, string posLat, string posLong, string positif, int organisateur_Id, int NIcon_Id, int recompense_Id, int bonus_Id, int mediaItem_Id, int nEvenement_Id);
    }
}
