using Tag_Go.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.NVote;

namespace Tag_Go.BLL.Interfaces
{
    public interface INVoteService
    {
        bool Create(NVote nVote);
        void CreateVote(NVote nVote);
        IEnumerable<NVote?> GetAll();
        NVote? GetById(int nVote_Id);
        NVote? Delete(int nVote_Id);
    }
}
