using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.AdminForms.CategoryForm;
using WinUI.AdminForms.FoodForm;
using WinUI.AdminForms.MealForm;
using WinUI.AdminForms.UserForm;
using WinUI.EFContextInjection;

namespace WinUI.AdminForms
{
    public partial class AdminParent : Form
    {
        private readonly IUserBLL _userBLL;

        public AdminParent(IUserBLL userBLL)
        {
            _userBLL = userBLL; 
            InitializeComponent();
        }

        private void Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string tag = item.Tag.ToString();
            Form frm = default;
            switch (tag)
            {
                case "user":
                    frm = EFContextForm.ConfigureServices<FrmUser>();
                    break;
                case "category":
                    frm = EFContextForm.ConfigureServices<FrmCategory>();
                    break;
                case "food":
                    frm = EFContextForm.ConfigureServices<FrmFood>();
                    break;
                case "meal":
                    frm = EFContextForm.ConfigureServices<FrmMeal>();
                    break;
                default:
                    break;
            }

            //Açılan forma göre Parent Containerın boyutunu ayarlar.
            this.Width = frm.Width + 20;
            this.Height = frm.Height + 70;

            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show(); ;
        }

        private void AdminParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
