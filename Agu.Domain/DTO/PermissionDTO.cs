using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Domain.DTO
{
    public class PermissionDTO
    {
        public int PermissionId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
