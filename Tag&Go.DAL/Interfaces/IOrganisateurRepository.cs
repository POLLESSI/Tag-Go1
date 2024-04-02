using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Organisateur;

namespace Tag_Go.DAL.Interfaces
{
    public interface IOrganisateurRepository
    {
        bool Create(Organisateur organisateur);
        void CreateOrganisateur(Organisateur organisateur);
        IEnumerable<Organisateur?> GetAll();
        Organisateur? GetById(int organisateur_Id);
        Organisateur? Delete(int organisateur_Id);
        Organisateur? Update(int organisateur_Id, string companyName, string businessNumber, int nUser_Id, string point);
    }
}
