using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Hubs;
using Tag_Go.DAL.Interfaces;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Tools;
//using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaItemController : ControllerBase
    {
        private readonly IMediaItemRepository _mediaItemRepository;
        private readonly MediaItemHub _mediaItemHub;
        private readonly Dictionary<string, string> _currentMediaItem = new Dictionary<string, string>();

        public MediaItemController(IMediaItemRepository mediaItemRepository, MediaItemHub mediaItemHub)
        {
            _mediaItemRepository = mediaItemRepository;
            _mediaItemHub = mediaItemHub;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mediaItemRepository.GetAll());
        }
        [HttpGet("{mediaItem_Id}")]
        public ActionResult GetById(int mediaItem_Id)
        {
            return Ok(_mediaItemRepository.GetById(mediaItem_Id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(MediaItemRegisterForm newMediaItem)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_mediaItemRepository.Create(newMediaItem.MediaItemToDal()))
            {
                await _mediaItemHub.RefreshMediaItem();
                return Ok(newMediaItem);
            }
            return BadRequest("Registration Horror");
        }
        [HttpDelete("{mediaItem_Id}")]
        public IActionResult Delete(int mediaItem_Id)
        {
            _mediaItemRepository.Delete(mediaItem_Id);
            return Ok();
        }
        [HttpPut("{mediaItem_Id}")]
        public IActionResult Update(int mediaItem_Id, string mediaType, string urlItem, string description)
        {
            _mediaItemRepository.Update(mediaItem_Id, mediaType, urlItem, description);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveMediaItemUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentMediaItem[item.Key] = item.Value;
            }
            return Ok(_currentMediaItem);
        }
        //[HttpOptions("{mediaitem_id}")]
        //IActionResult PrefligthRoute(int mediaItem_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/MediaItem
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{mediaitem_id}")]
        //IActionResult PutTodoItem(int mediaItem_Id)
        //{
        //    if (mediaItem_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(mediaItem_Id);
        //}
    }
}
