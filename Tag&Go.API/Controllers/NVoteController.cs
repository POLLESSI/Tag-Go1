using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Hubs;
using Tag_Go.DAL.Interfaces;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Tools;
using System.Security.Cryptography;
//using System.Reflection.Metadata.Ecma335;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NVoteController : ControllerBase
    {
        private readonly INVoteRepository _nVoteRepository;
        private readonly NVoteHub _nVoteHub;
        private readonly Dictionary<string, string> _currentNVote = new Dictionary<string, string>();

        public NVoteController(INVoteRepository nVoteRepository, NVoteHub nVoteHub)
        {
            _nVoteRepository = nVoteRepository;
            _nVoteHub = nVoteHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nVoteRepository.GetAll());
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(NVoteRegisterForm nVote)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_nVoteRepository.Create(nVote.NVoteToDal()))
            {
                await _nVoteHub.RefreshVote();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{nVote_Id}")]
        public IActionResult Delete(int nVote_Id)
        {
            _nVoteRepository.Delete(nVote_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveVoteUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNVote[item.Key] = item.Value;
            }
            return Ok(_currentNVote);
        }
        //[HttpOptions("{vote_id}")]
        //IActionResult PrefligthRoute(int voteId)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/Vote
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("vote_id")]
        //IActionResult PutTodoItem(int voteId) 
        //{
        //    if (voteId < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(voteId);
        //}
    }
}
