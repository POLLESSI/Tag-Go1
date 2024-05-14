using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.NPerson;

namespace Tag_Go.DAL.Interfaces
{
    public interface INPersonRepository
    {
        bool Create(NPerson nPerson);
        void CreatePerson(NPerson nPerson);
        IEnumerable<NPerson?> GetAll();
        NPerson? GetById(int nPerson_Id);
        NPerson? Delete(int nPerson_Id);
        NPerson? Update(string lastname, string firstname, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm, int nPerson_Id);
    }
}
