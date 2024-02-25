using Agu.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Interface.Business
{
    public interface IUserRoleManager
    {
        void AddDefaultUserRole();
        List<UserRoleDTO> GetRoleList();
        ResponseDTO AddUserRole(UserRoleDTO userRoleDTO);
        ResponseDTO EditUserRole(UserRoleDTO userRoleDTO);
    }
}
