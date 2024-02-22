using Agu.Domain.Core;
using Agu.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Interface.Business
{
    public interface IUserManger
    {
        void AddDefaultUser(User user);
        List<UserDTO> GetUserList();
    }
}
