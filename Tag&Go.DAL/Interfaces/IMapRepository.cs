using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Map;

namespace Tag_Go.DAL.Interfaces
{
    public interface IMapRepository
    {
        bool Create(Map map);
        void CreateMap(Map map);
        IEnumerable<Map?> GetAll();
        Map? GetById(int map_Id);
        Map? Delete(int map_Id);
        Map? Update(int map_Id, DateTime dateCreation, string mapUrl, string description);
    }
}
