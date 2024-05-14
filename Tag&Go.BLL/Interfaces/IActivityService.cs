using Tag_Go.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.Activity;

namespace Tag_Go.BLL.Interfaces
{
    public interface IActivityService
    {
        bool Create(Activity activity);
        void CreateActivity(Activity activity);
        IEnumerable<Activity?> GetAll();
        Activity? GetById(int activity_Id);
        Activity? Delete(int activity_Id);
        Activity? Update(int activity_Id, string activityName, string activityAddress, string activityDescription, string complementareInformation, string posLat, string posLong, int organisateur_Id);
    }
}
