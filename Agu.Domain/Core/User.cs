﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Domain.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int RoleId { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ? UpdatedOn { get; set; }
    }
}
