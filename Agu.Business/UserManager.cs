using Agu.Domain.Core;
using Agu.Domain.DTO;
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
    public class UserManager : IUserManager
    {
        private IAgDbContext _agDbContext;

        public UserManager(IAgDbContext agDbContext)
        {
            _agDbContext = agDbContext;
        }
        public void AddDefaultUser(User user)
        {
            var newUser = _agDbContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (newUser == null)
            {
                var superAdmin = _agDbContext.UserRoles.Where(x => x.Name == "Super Admin").FirstOrDefault();
                if (superAdmin != null)
                {

                    // first we create Admin role   
                    var superAdminUser = new User
                    {
                        FullName = user.FullName,
                        RoleId = superAdmin.Id,
                        Email = user.Email,
                        UserName = user.UserName,
                        Password = Base64Encode(user.Password),
                        Active = true,
                        CreatedOn = DateTime.Now

                    };

                    _agDbContext.Users.Add(superAdminUser);
                    _agDbContext.SaveChanges();
                }
            }
        }
        public List<UserDTO> GetUserList()
        {
            var userList = _agDbContext.Users.Join(
                _agDbContext.UserRoles,
                user => user.RoleId, role => role.Id,
                 (user,role)=> new UserDTO
                 { 
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                Active= user.Active,
                CreatedOn = user.CreatedOn,
                UserRole = role.Name,
                RoleId= user.RoleId,
                Password= Base64Decode(user.Password),
                UpdatedOn = user.UpdatedOn,

            }).ToList();
            return userList;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
