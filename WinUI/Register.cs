using BLL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systm;
using ViewModels.UserViewModels;

namespace WinUI
{
    public partial class Register : Form
    {
        private readonly IUserBLL _userBLL;

        public Register(IUserBLL userBLL)
        {
            _userBLL = userBLL;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            UserCreateVM vm = new UserCreateVM()
            {
                UserName = userName,
                Password = password,
                Email = email,
            };

            ResultService<User> newUser = _userBLL.CreateUser(vm);

            if (newUser.HasError)
            {
                string errorMessage = newUser.ErrorItems.ToList().First().ErrorMessage;
                string errorType = newUser.ErrorItems.ToList()[0].ErrorType;

                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
