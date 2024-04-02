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
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonHub _personHub;
        private readonly Dictionary<string, string> _currentPerson = new Dictionary<string, string>();

        public PersonController(IPersonRepository personRepository, PersonHub personHub)
        {
            _personRepository = personRepository;
            _personHub = personHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personRepository.GetAll());
        }
        [HttpGet("{person_id}")]
        public IActionResult GetById(int person_Id)
        {
            return Ok(_personRepository.GetById(person_Id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(PersonRegisterForm person)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_personRepository.Create(person.PersonToDal()))
            {
                await _personHub.RefreshPerson();
                return Ok(person);
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{person_id}")]
        public IActionResult Delete(int person_Id)
        {
            _personRepository.Delete(person_Id);
            return Ok();
        }
        [HttpPut("{person_id}")]
        public IActionResult Update(int person_Id, string lastname, string firstname, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm) 
        {
            _personRepository.Update(person_Id, lastname, firstname, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceivePersonUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentPerson[item.Key] = item.Value;
            }
            return Ok(_currentPerson);
        }
    }
}
