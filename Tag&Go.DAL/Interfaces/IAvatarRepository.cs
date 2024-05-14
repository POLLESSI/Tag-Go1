﻿using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Avatar;

namespace Tag_Go.DAL.Interfaces
{
    public interface IAvatarRepository
    {
        bool Create(Avatar avatar);
        void CreateAvatar(Avatar avatar);
        IEnumerable<Avatar?> GetAll();
        Avatar? GetById(int avatar_Id);
        Avatar? Delete(int avatar_Id);
        Avatar? Update(int avatar_Id, string avatarName, string avatarUrl, string description);
    }
}
