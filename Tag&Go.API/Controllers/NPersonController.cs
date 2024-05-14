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
    public class NPersonController : ControllerBase
    {
        private readonly INPersonRepository _nPersonRepository;
        private readonly NPersonHub _nPersonHub;
        private readonly Dictionary<string, string> _currentNPerson = new Dictionary<string, string>();

        public NPersonController(INPersonRepository nPersonRepository, NPersonHub nPersonHub)
        {
            _nPersonRepository = nPersonRepository;
            _nPersonHub = nPersonHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nPersonRepository.GetAll());
        }
        [HttpGet("{person_Id}")]
        public IActionResult GetById(int nPerson_Id)
        {
            return Ok(_nPersonRepository.GetById(nPerson_Id));
        }
        //[Authorize("AdminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(NPersonRegisterForm nPerson)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_nPersonRepository.Create(nPerson.NPersonToDal()))
            {
                await _nPersonHub.RefreshPerson();
                return Ok(nPerson);
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{nPerson_Id}")]
        public IActionResult Delete(int nPerson_Id)
        {
            _nPersonRepository.Delete(nPerson_Id);
            return Ok();
        }
        [HttpPut("{nPerson_Id}")]
        public IActionResult Update(string lastname, string firstname, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm, int nPerson_Id)
        {
            _nPersonRepository.Update(lastname, firstname, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm, nPerson_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceivePersonUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNPerson[item.Key] = item.Value;
            }
            return Ok(_currentNPerson);
        }
    }
}
