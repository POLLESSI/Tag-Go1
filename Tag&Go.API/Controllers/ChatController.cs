using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Models;
using Tag_Go.API.Hubs;
using Tag_Go.API.Tools;
using Tag_Go.DAL.Interfaces;
using System.Security.Cryptography;
//using System.Reflection.Metadata.Ecma335;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;
        private readonly ChatHub _chatHub;

        public ChatController(IChatRepository chatRepository, ChatHub chatHub)
        {
            _chatRepository = chatRepository;
            _chatHub = chatHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_chatRepository.GetAll());
        }
        [HttpGet("{chat_Id}")]
        public IActionResult GetById(int chat_Id)
        {
            return Ok(_chatRepository.GetById(chat_Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Message newMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_chatRepository.Create(newMessage.ChatToDal()))
            {
                await _chatHub.RefreshChat();
                return Ok(newMessage);
            }
            return BadRequest("Registration error");
        }
        [HttpDelete("{chat_Id}")]
        public IActionResult Delete(int chat_Id)
        {
            _chatRepository.Delete(chat_Id);
            return Ok();
        }
        [HttpOptions("{chat_Id}")]
        IActionResult PrefligthRoute(int chat_Id)
        {
            return NoContent();
        }
        [HttpOptions]
        IActionResult PrefligthRoute()
        {
            return NoContent();
        }
        [HttpPut("{chat_Id}")]
        IActionResult PutTodoItem(int chat_Id)
        {
            if (chat_Id < 1)
            {
                return BadRequest();
            }
            return Ok(chat_Id);
        }
    }
}
