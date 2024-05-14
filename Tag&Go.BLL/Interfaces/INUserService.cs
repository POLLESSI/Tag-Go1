﻿using Tag_Go.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.NUser;

namespace Tag_Go.BLL.Interfaces
{
    public interface INUserService
    {
        bool Create(NUser nUser);
        void CreateNUser(NUser nUser);
        IEnumerable<NUser?> GetAll();
        NUser? GetById(int nUser_Id);
        NUser? Delete(int nUser_Id);
        NUser? Update(int nUser_Id, string? email, string? pwd, int nPerson_Id, string? role_Id, int avatar_Id, string? point);
        bool RegisterNUser(string? email, string? pwd, int nPerson_Id, string? role_Id, int avatar_Id, string? point);
        NUser? LoginNUser(string? email, string? pwd);
        void SetRole(int nUser_Id, string? role_Id);
    }
}
