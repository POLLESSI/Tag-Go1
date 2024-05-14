using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.NIcon;

namespace Tag_Go.DAL.Interfaces
{
    public interface INIconRepository
    {
        bool Create(NIcon nIcon);
        void CreateIcon(NIcon nIcon);
        IEnumerable<NIcon?> GetAll();
        NIcon? GetById(int nIcon_Id);
        NIcon? Delete(int nIcon_Id);
        NIcon? Update(string nIconName, string nIconDescription, string nIconUrl, int nIcon_Id);
    }
}
