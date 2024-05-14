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
    public class OrganisateurController : ControllerBase
    {
        private readonly IOrganisateurRepository _organisateurRepository;
        private readonly OrganisateurHub _organisateurHub;
        private readonly Dictionary<string, string> _currentOrganisateur = new Dictionary<string, string>();

        public OrganisateurController(IOrganisateurRepository organisateurRepository, OrganisateurHub organisateurHub)
        {
            _organisateurRepository = organisateurRepository;
            _organisateurHub = organisateurHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_organisateurRepository.GetAll());
        }
        [HttpGet("{organisateur_id}")]
        public IActionResult GetById(int organisateur_Id)
        {
            return Ok(_organisateurRepository.GetById(organisateur_Id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(OrganisateurRegisterForm newOrganisateur)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_organisateurRepository.Create(newOrganisateur.OrganisateurToDal()))
            {
                await _organisateurHub.RefreshOrganisateur();
                return Ok(newOrganisateur);
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{organisateur_id}")]
        public IActionResult Delete(int organisateur_Id)
        {
            _organisateurRepository.Delete(organisateur_Id);
            return Ok();
        }
        [HttpPut("{organisateur_Id}")]
        public IActionResult Update(string companyName, string businessNumber, int nUser_Id, string point, int organisateur_Id)
        {
            _organisateurRepository.Update(companyName, businessNumber, nUser_Id, point, organisateur_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveOrganisateurUpdate(Dictionary<string, string> newOrganisateur)
        {
            foreach (var item in newOrganisateur)
            {
                _currentOrganisateur[item.Key] = item.Value;
            }
            return Ok(_currentOrganisateur);
        }
        //[HttpOptions("{organisateur_id}")]
        //IActionResult PrefligthRoute(int organisateur_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/Organisateur
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("organisateur_id")]
        //IActionResult PutTodoItem(int organisateur_Id)
        //{
        //    if (organisateur_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(organisateur_Id);
        //}
    }
}
