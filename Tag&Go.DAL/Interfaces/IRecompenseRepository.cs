using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Recompense;

namespace Tag_Go.DAL.Interfaces
{
    public interface IRecompenseRepository
    {
        bool Create(Recompense recompense);
        void CreateRecompense(Recompense recompense);
        IEnumerable<Recompense?> GetAll();
        Recompense? GetById(int recompense_Id);
        Recompense? Delete(int recompense_Id);
        Recompense? Update(int recompense_Id, string definition, string point, string implication, string granted);
    }
}
