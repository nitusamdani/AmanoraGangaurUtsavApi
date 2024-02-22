using Agu.Business;
using Agu.Domain.DTO;
using Agu.Interface.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmanoraGangaurUtsav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            List<UserDTO> list = _userManager.GetUserList();


            return Ok(list);
        }
    }
}