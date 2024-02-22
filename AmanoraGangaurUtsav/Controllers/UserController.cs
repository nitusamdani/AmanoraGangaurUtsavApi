using Agu.Business;
using Agu.Domain.DTO;
using Agu.Interface.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmanoraGangaurUtsav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :  ControllerBase
    {
        private IUserManger _userManeger;
    public UserController(IUserManger userManeger)
    {
            _userManeger = userManeger;
    }

    [HttpGet]
    public ActionResult GetUsers()
        {
        List<UserDTO> list = _userManeger.GetUserList();


        return Ok(list);
    }
}
}