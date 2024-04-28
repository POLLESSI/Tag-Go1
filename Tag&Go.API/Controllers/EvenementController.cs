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
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementRepository _evenementRepository;
        private readonly EvenementHub _evenementHub;
        private readonly Dictionary<string, string> _currentEvenement = new Dictionary<string, string>();

        public EvenementController(IEvenementRepository evenementRepository, EvenementHub evenementHub)
        {
            _evenementRepository = evenementRepository;
            _evenementHub = evenementHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_evenementRepository.GetAll());
        }
        [HttpGet("{evenement_id}")]
        public IActionResult GetById(int evenement_Id)
        {
            return Ok(_evenementRepository.GetById(evenement_Id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(EvenementRegisterForm evenement)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_evenementRepository.Create(evenement.EvenementToDal()))
            {
                await _evenementHub.RefreshEvenement();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{evenement_id}")]
        public IActionResult Delete(int evenement_Id)
        {
            _evenementRepository.Delete(evenement_Id);
            return Ok();
        }
        [HttpPut("{evenement_id}")]
        public IActionResult Update(int evenement_Id, DateTime EvenementDate, string evenementName, string evenementDescription, string posLat, string posLong, string positif, int organisateur_Id, int icon_Id, int recompense_Id, int bonus_Id, int mediaItem_Id)
        {
            _evenementRepository.Update(evenement_Id, EvenementDate, evenementDescription, posLat, posLong, positif, organisateur_Id, icon_Id, recompense_Id, bonus_Id, mediaItem_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveEvenementUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentEvenement[item.Key] = item.Value;
            }
            return Ok(_currentEvenement);
        }
        //[HttpOptions("{evenement_id}")]
        //IActionResult PrefligthRoute(int evenement_Id)
        //{
        //    return NoContent();
        //}
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{evenement_id}")]
        //IActionResult PutTodoItem(int evenement_Id)
        //{
        //    if (evenement_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(evenement_Id);
        //}
    }
}
