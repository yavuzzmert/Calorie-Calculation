using BLL.Abstract;
using Entities;
using Systm;
using ViewModels.UserViewModels;
using WinUI.AdminForms;
using WinUI.EFContextInjection;

namespace WinUI
{
    public partial class Login : Form
    {
        private readonly IUserBLL _userBLL;

        public Login(IUserBLL userBLL)
        {
            _userBLL = userBLL; 
            InitializeComponent();
        }

        private void btnLoginClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();
            switch (tag)
            {
                case "Login":
                    LoginOnClick();
                    break;
                case "Register":
                    RegisterOnClick();
                    break;
            }
        }

        private void RegisterOnClick()
        {
            Form frm = EFContextForm.ConfigureServices<Register>();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void LoginOnClick()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            LoginVM login = new LoginVM
            {
                UserName = userName,
                Password = password
            };
            ResultService<User> user = _userBLL.Login(login);
            GetUserTypes(user);
        }

        private void GetUserTypes(ResultService<User> user)
        {
            if (user.HasError)
            {
                string errorMessage = user.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = user.ErrorItems.ToList()[0].ErrorType;

                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form frm = default;

                if (user.Data.UserTypes == UserTypes.Admin)
                {
                    frm = EFContextForm.ConfigureServices<AdminParent>();
                }
                frm.Show();
                this.Hide();
            }
        }
    }
}
