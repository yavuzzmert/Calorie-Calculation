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
using ViewModels.CategoryViewModels;
using ViewModels.FoodViewModels;
using ViewModels.MealViewModels;

namespace WinUI.AdminForms.FoodForm
{
    public partial class FrmFood : Form
    {
        private readonly IFoodBLL _foodBLL;

        public FrmFood(IFoodBLL foodBLL)
        {
            _foodBLL = foodBLL;
            InitializeComponent();
        }

        private void FrmFood_Load(object sender, EventArgs e)
        {
            FillWithList();
        }

        private void FillWithList()
        {
            lstFood.Items.Clear();
            ResultService<FoodBaseVM> result = _foodBLL.GetAllFood();
            if (!result.HasError)
            {
                string[] mealNames = result.ListData.Select(x => x.FoodName).ToArray();
                lstFood.Items.AddRange(mealNames);
            }
        }

        private void Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();

            switch (tag)
            {
                case "create":
                    CreateFood();
                    break;
                case "update":
                    UpdateFood();
                    break;
                case "delete":
                    DeleteFood();
                    break;
            }
        }

        private void DeleteFood()
        {
            string foodName = lstFood.SelectedItem as string;
            ResultService<Food> result = _foodBLL.GetFood(foodName);

            if (!result.HasError)
            {
                FoodBaseVM @base = new FoodBaseVM()
                {
                    Id = result.Data.ID,
                };
                ResultService<FoodBaseVM> baseResult = _foodBLL.DeleteFood(@base.Id);
                if (baseResult.HasError)
                {
                    string errorMessage = baseResult.ErrorItems.First().ErrorMessage;
                    string errorType = baseResult.ErrorItems.First().ErrorType;
                    MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarılı!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillWithList();
                }
            }
            else
            {
                string errorMessage = result.ErrorItems.First().ErrorMessage;
                string errorType = result.ErrorItems.First().ErrorType;
                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFood()
        {
            string foodName = lstFood.SelectedItem as string;
            ResultService<Food> result = _foodBLL.GetFood(foodName);
            if (!result.HasError)
            {
                FoodUpdateVM vm = new FoodUpdateVM()
                {
                    Id = result.Data.ID,
                    FoodName = txtFoodName.Text,
                    Calorie = Convert.ToDouble(txtCalorie.Text),
                };
                ResultService<FoodUpdateVM> updateResult = _foodBLL.UpdateFood(vm);
                if (updateResult.HasError)
                {
                    string errorMessage = updateResult.ErrorItems.First().ErrorMessage;
                    string errorType = updateResult.ErrorItems.First().ErrorType;
                    MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillWithList();
                }
            }
            else
            {
                string errorMessage = result.ErrorItems.First().ErrorMessage;
                string errorType = result.ErrorItems.First().ErrorType;
                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateFood()
        {
            FoodCreateVM vm = new FoodCreateVM()
            {
                FoodName= txtFoodName.Text,
                Calorie= Convert.ToDouble(txtCalorie.Text),
            };
            ResultService<Food> result = _foodBLL.CreateFood(vm);
            GetResult(result);
            FillWithList();
        }

        private void GetResult(ResultService<Food> result)
        {
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.FirstOrDefault().ErrorMessage;
                string errorType = result.ErrorItems.FirstOrDefault().ErrorType;
                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarılı!", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            string foodName = lstFood.SelectedItem.ToString();
            txtFoodName.Text = _foodBLL.GetFood(foodName).Data.FoodName;
        }
    }
}
