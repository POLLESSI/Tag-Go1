using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Hubs;
using Tag_Go.DAL.Interfaces;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Tools;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteRepository _voteRepository;
        private readonly VoteHub _voteHub;
        private readonly Dictionary<string, string> _currentVote = new Dictionary<string, string>();

        public VoteController(IVoteRepository voteRepository, VoteHub voteHub)
        {
            _voteRepository = voteRepository;
            _voteHub = voteHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_voteRepository.GetAll());
        }
        [HttpGet("create")]
        public async Task<IActionResult> Create(VoteRegisterForm vote)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_voteRepository.Create(vote.VoteToDal()))
            {
                await _voteHub.RefreshVote();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{vote_id}")]
        public IActionResult Delete(int vote_Id)
        {
            _voteRepository.Delete(vote_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveVoteUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentVote[item.Key] = item.Value;
            }
            return Ok(_currentVote);
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
