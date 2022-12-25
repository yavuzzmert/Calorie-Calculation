using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systm;
using ViewModels.UserViewModels;

namespace BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        ResultService<User> CreateUser(UserCreateVM vm);

        ResultService<User> Login(LoginVM vm);

        bool AnyUser(UserCreateVM vm);

        bool IsValidEmail(string email);

        ResultService<User> GetUserByUserName(string userName);

        ResultService<User> GetUserById(int id);

        ResultService<User> UpdateUser(UserUpdateVM vm);

        ResultService<User> DeleteUser(UserBaseVM vm);
    }
}
