using Agu.Domain.Core;
using Agu.Interface.Business;
using Agu.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Business
{
    public class UserRoleManager : IUserRoleManger
    {
        private IAgDbContext _agDbContext;

        public UserRoleManager(IAgDbContext agDbContext)
        {
            _agDbContext = agDbContext;
        }
        public void AddDefaultUserRole()
        {
            var superAdmin = _agDbContext.UserRoles.Where(x => x.Name == "Super Admin").FirstOrDefault();
            if (superAdmin == null)
            {

                // first we create Admin role   
                var userRole = new UserRole
                {
                    Name = "Super Admin",
                    Active = true,
                    CreatedOn = DateTime.Now
                    //UpdatedOn = null,

                };

                _agDbContext.UserRoles.Add(userRole);
                _agDbContext.SaveChanges();
            }
        }
    }

}
