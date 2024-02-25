using Agu.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Interface.Repository
{
    public interface IAgDbContext
    {
        
        DbSet<UserRole> UserRoles { set; get; }

        DbSet<User> Users { set; get; }

        DbSet<Permission> Permissions { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }
        int SaveChanges();
    }
}
