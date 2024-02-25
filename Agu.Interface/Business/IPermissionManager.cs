using Agu.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Interface.Business
{
    public interface IPermissionManager
    {
        //List<RolePermissionListDTO> GetPermissionList();

        List<RolePermissionListDTO> GetPermissionList(int roleId);
        ResponseDTO AddOrUpdateRolePermission(RolePermissionListDTO userRoleDTO);
        
    }
}
