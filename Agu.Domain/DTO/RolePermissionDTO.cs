using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Domain.DTO
{
    public class RolePermissionDTO
    {
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public string Action { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }

    }

    public class RolePermissionListDTO
    {
        public int RoleId { get; set; }
        public LinkedList<RolePermissionDTO> RolePermissions { get; set; }
    }
}
