using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Icon;

namespace Tag_Go.DAL.Interfaces
{
    public interface IIconRepository
    {
        bool Create(Icon icon);
        void CreateIcon(Icon icon);
        IEnumerable<Icon?> GetAll();
        Icon? GetById(int icon_Id);
        Icon? Delete(int icon_Id);
        Icon? Update(int icon_Id, string iconName, string iconDescription, string iconUrl);
    }
}
