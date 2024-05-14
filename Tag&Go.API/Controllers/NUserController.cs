using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Tools;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.DAL.Interfaces;
using Tag_Go.DAL.Entities;
//using Tag_Go.BLL.Models;
//using Microsoft.AspNetCore.Authorization;
using Tag_Go.API.Hubs;
using System.Security.Cryptography;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Text.RegularExpressions;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NUserController : ControllerBase
    {
        private readonly INUserRepository _userRepository;
        private readonly TokenGenerator _tokenGenerator;
        private readonly NUserHub _nUserHub;
        private readonly Dictionary<string, string> _currentNUser = new Dictionary<string, string>();

        public NUserController(INUserRepository userRepository, TokenGenerator tokenGenerator, NUserHub nUserHub)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _nUserHub = nUserHub;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }
        [HttpGet("{nuser_Id}")]
        public ActionResult GetById(int nUser_Id)
        {
            return Ok(_userRepository.GetById(nUser_Id));
        }
        [HttpPost("login")]
        public IActionResult Login(NUserRegisterForm nUser)
        {
            try
            {
                NUser? connectedNUser = _userRepository.LoginNUser(nUser.Email, nUser.Pwd);
                string? MdpNUser = nUser.Pwd;
                string? hashpwd = connectedNUser.Pwd;
                bool motDePassValide = BCrypt.Net.BCrypt.Verify(MdpNUser, hashpwd);
                if (motDePassValide)
                {
                    return Ok(_tokenGenerator.GenerateToken(connectedNUser));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register")]
        public IActionResult Register(NewNUser nUser)
        {
            _userRepository.RegisterNUser(nUser.Email, nUser.Pwd, nUser.NPerson_Id, nUser.Role_Id, nUser.Avatar_Id, nUser.Point);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NUserRegisterForm nUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_userRepository.Create(nUser.NUserToDal()))
            {
                await _nUserHub.RefreshNUser();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("nuser_Id")]
        public IActionResult Delete(int nUser_Id)
        {
            _userRepository.Delete(nUser_Id);
            return Ok();
        }
        [HttpPut("nuser_Id")]
        public IActionResult Update(int nUser_Id, string? email, string? pwd, int nPerson_Id, string role_Id, int avatar_Id, string? point)
        {
            _userRepository.Update(nUser_Id, email, pwd, nPerson_Id, role_Id, avatar_Id, point);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveNUserUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNUser[item.Key] = item.Value;
            }
            return Ok(_currentNUser);
        }
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole role)
        {
            _userRepository.SetRole(role.NUser_Id, role.Role_Id);
            return Ok();
        }
        //[HttpOptions("{nuser_id}")]
        //IActionResult PrefligthRoute(Guid nUser_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/NUser
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{nuser_id}")]
        //IActionResult PutTodoItem(Guid nUser_Id)
        //{
        //    if (nUser_Id == Guid.Empty)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(nUser_Id);
        //}
    }
}
