using BLL.Abstract;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Systm;
using ViewModels.UserViewModels;

namespace BLL.Concrete
{
    public class UserService : IUserBLL
    {
        private readonly IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool AnyUser(UserCreateVM vm)
        {
            bool validUser = _userDAL.GetAll(x => x.IsActive)
                               .Any(x => x.Email == vm.Email && x.Password == vm.Password);

            return validUser;
        }

        public ResultService<User> CreateUser(UserCreateVM vm)
        {
            ResultService<User> result = new ResultService<User>();

            bool checkUser = AnyUser(vm);
            bool checkEmail = IsValidEmail(vm.Email);

            if (checkEmail)
            {
                if (!checkUser)
                {
                    User newUser = new User()
                    {
                        UserName = vm.UserName,
                        Email = vm.Email,
                        Password = vm.Password,
                        UserTypes = vm.UserTypes,
                        CreateOn = vm.CreateDate
                    };

                    User addUser = _userDAL.Add(newUser);

                    result.Data = addUser ?? newUser;

                    if (addUser == null)
                    {
                        result.AddError("Bir hata oluştu", "Kayıt işlemi başarısız");
                    }
                }
                else
                {
                    result.Data = null;
                    result.AddError("Ekleme başarısız", "Kayıt zaten var");
                }

            }
            else
            {
                result.Data = null;
                result.AddError("Ekleme başarısız", "Email formatı uygun değil");
            }

            return result;
        }

        public ResultService<User> DeleteUser(UserBaseVM vm)
        {
            ResultService<User> result = new ResultService<User>();

            User user = _userDAL.Get(x => x.IsActive && x.ID.Equals(vm.Id));

            try
            {
                user.IsActive = false;
                _userDAL.Delete(user);
            }
            catch (Exception)
            {
                result.Data = null;
                result.AddError("Silme işlemi başarısız", "Kayıt bulunamadı");
            }
            return result;
        }

        public ResultService<User> GetUserById(int id)
        {
            ResultService<User> result = new ResultService<User>();

            try
            {
                result.Data = _userDAL.Get(x => x.ID.Equals(id));

            }
            catch (Exception)
            {
                result.AddError("Hata", "Kayıt bulunamadı");
            }

            return result;
        }

        public ResultService<User> GetUserByUserName(string userName)
        {
            ResultService<User> result = new ResultService<User>();

            User user = _userDAL.Get(x => x.UserName.Equals(userName));

            if (user != null)
            {
                result.Data = user;
            }
            else
            {
                result.Data = null;
                result.AddError("Hata", "Kullanıcı adı bulunamadı");
            }

            return result;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"[\w+-]+(?:.[\w+-]+)@[\w+-]+(?:.[\w+-]+)(?:.[a-zA-Z]{2,4})";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public ResultService<User> Login(LoginVM vm)
        {
            ResultService<User> result = new ResultService<User>();

            User user = _userDAL.Get(x => x.UserName.Equals(vm.UserName) && x.Password.Equals(vm.Password));

            if (user != null)
            {
                result.Data = user;
            }
            else
            {
                result.Data = null;
                result.AddError("Giriş başarısız", "Kullanıcı bulunamadı");
            }

            return result;
        }

        public ResultService<User> UpdateUser(UserUpdateVM vm)
        {
            ResultService<User> result = new ResultService<User>();

            try
            {
                User user = _userDAL.Get(x => x.ID.Equals(vm.Id) && x.IsActive);
                user.UserName = vm.UserName;
                user.Email = vm.Email;
                user.Password = vm.Password;
                user.UpdateOn = vm.UpdateDate;

                User updateUser = _userDAL.Update(user);

                result.Data = updateUser ?? user;

                if (updateUser == null)
                {
                    result.AddError("Hata", "Güncelleme başarısız");
                }
            }
            catch (Exception)
            {
                result.Data = null;
                result.AddError("Güncelleme başarısız", "Kayıt bulunamadıs");
            }
            return result;
        }
    }
}
