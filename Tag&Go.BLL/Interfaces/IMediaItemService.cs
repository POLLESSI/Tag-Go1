using Tag_Go.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.MediaItem;

namespace Tag_Go.BLL.Interfaces
{
    public interface IMediaItemService
    {
        bool Create(MediaItem mediaItem);
        void CreateMediaItem(MediaItem mediaItem);
        IEnumerable<MediaItem?> GetAll();
        MediaItem? GetById(int mediaItem_Id);
        MediaItem? Delete(int mediaItem_Id);
        MediaItem? Update(int mediaItem_Id, string mediaType, string urlItem, string description);
    }
}
