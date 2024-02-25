using Agu.Domain.DTO;
using Agu.Interface.Business;
using AmanoraGangaurUtsav.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace AmanoraGangaurUtsav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IUserRoleManager _userRoleManager;
        public RoleController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }
        [HttpGet]
        public IActionResult GetUserRoles()
        {
            List<UserRoleDTO> list = _userRoleManager.GetRoleList();
            ResponseDTO responseDTO = new ResponseDTO();
            responseDTO.StatusCode = (int)HttpStatusCode.OK;
            responseDTO.Status = true;
            responseDTO.StatusMessage =list.Count> 0 ? "":"No Record found";
            responseDTO.Data = list;
            return Ok(responseDTO);
        }

        [Route("AddRole")]
        [HttpPost]
        public IActionResult AddRole(UserRoleCreateViewModel userRoleViewModel)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            if (! ModelState.IsValid)
            {
                responseDTO.StatusCode=(int)HttpStatusCode.BadRequest;
                responseDTO.StatusMessage =string.Join(",", ModelState.Values.SelectMany(f=> f.Errors).Select(f=> f.ErrorMessage));
                return BadRequest(responseDTO);
            }

            responseDTO = _userRoleManager.AddUserRole(new UserRoleDTO
            {
                Name = userRoleViewModel.Name,
                Active = true
            });

            
            return Ok(responseDTO);
        }

        [Route("UpdateRole")]
        [HttpPost]
        public IActionResult UpdateRole(UserRoleEditViewModel userRoleViewModel)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            if (!ModelState.IsValid)
            {
                responseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
                responseDTO.StatusMessage = string.Join(",", ModelState.Values.SelectMany(f => f.Errors).Select(f => f.ErrorMessage));
                return BadRequest(responseDTO);
            }

            responseDTO = _userRoleManager.EditUserRole(new UserRoleDTO
            {
                Id= userRoleViewModel.Id,
                Name = userRoleViewModel.Name,
                Active = userRoleViewModel.Active
            });


            return Ok(responseDTO);
        }
    }
}
