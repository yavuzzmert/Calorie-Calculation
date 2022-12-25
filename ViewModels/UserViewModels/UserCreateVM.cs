using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserViewModels
{
    public class UserCreateVM
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserTypes UserTypes => UserTypes.Standard;

        public DateTime CreateDate => DateTime.Now;
    }
}
