using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userManager.GetUsers());
        }
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            return Ok(_userManager.PostUser(user));
        }
        [HttpPut]
        public IActionResult PutUser(User user, int ci)
        {
            User UserUpdadated = _userManager.PutUser(user, ci);
            if(UserUpdadated != null)
            {
                return Ok(UserUpdadated);
            }
            else
            {
                return BadRequest("El usuario no ha sido encontrado");
            }
            
        }
        
        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {
            return Ok(_userManager.DeleteUser(user));
        }
    }
}
