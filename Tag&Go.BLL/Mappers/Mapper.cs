using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tag_Go.BLL.Models;
using Tag_Go.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Tag_Go.BLL.Mappers
{
    public static class Mapper
    {
        internal static NUser BllToDal(this NUserModel model)
        {
            return new NUser()
            {
                NUser_Id = model.NUser_Id,
                Email = model.Email,
                Pwd = model.Pwd,
                Person_Id = model.Person_Id,
                Role_Id = model.Role_Id,
            };
        }
        internal static NUserModel? DalToBll(this NUser entity)
        {
            if (entity is null) return null;
            return new NUserModel()
            {
                NUser_Id = entity.NUser_Id,
                Email = entity.Email,
                Pwd = entity.Pwd,
                Person_Id = entity.Person_Id,
                Role_Id = entity.Role_Id,
            };
        }
    }
}
