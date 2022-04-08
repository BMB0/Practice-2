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
            if (string.IsNullOrEmpty(user.Name) || user.Ci <= 0)
            {
                return BadRequest("El usuario no puede ser vacio");
            }
            
            User UserPosted = _userManager.PostUser(user);
            
            if (UserPosted == null)
            {
                return BadRequest("El usuario ya existe");
            }
            else
            {
                return Ok(UserPosted);
            }
        }
        [HttpPut]
        public IActionResult PutUser(User user, int ciToSearch)
        {
            if (string.IsNullOrEmpty(user.Name) || user.Ci <= 0 || ciToSearch <= 0)
            {
                return BadRequest("El usuario o el Ci no pueden ser vacios");
            }
            
            User UserUpdadated = _userManager.PutUser(user, ciToSearch);
            
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
            if (string.IsNullOrEmpty(user.Name) || user.Ci <= 0)
            {
                return BadRequest("El usuario no puede ser vacio");
            }
            
            User UserDeleted = _userManager.DeleteUser(user);
            
            if (UserDeleted != null)
            {
                return Ok(UserDeleted);
            }
            else
            {
                return BadRequest("El usuario no ha sido encontrado");
            }
        }
    }
}
