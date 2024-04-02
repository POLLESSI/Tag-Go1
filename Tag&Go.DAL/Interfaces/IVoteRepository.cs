using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Vote;

namespace Tag_Go.DAL.Interfaces
{
    public interface IVoteRepository
    {
        bool Create(Vote vote);
        void CreateVote(Vote vote);
        IEnumerable<Vote?> GetAll();
        Vote? GetById(int vote_Id);
        Vote? Delete(int vote_Id);
    }
}
