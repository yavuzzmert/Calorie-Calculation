using Entities;


namespace ViewModels.UserViewModels
{
    public class UserBaseVM
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public UserTypes UserTypes { get; set; }
    }
}
