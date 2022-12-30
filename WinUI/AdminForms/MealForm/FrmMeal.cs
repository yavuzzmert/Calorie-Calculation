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
using ViewModels.MealViewModels;

namespace WinUI.AdminForms.MealForm
{
    public partial class FrmMeal : Form
    {
        private readonly IMealBLL _mealBLL;

        public FrmMeal(IMealBLL mealBLL)
        {
            _mealBLL = mealBLL; 
            InitializeComponent();
        }

        private void FrmMeal_Load(object sender, EventArgs e)
        {
            FillWithList();
        }

        private void FillWithList()
        {
            lstMeal.Items.Clear();

            ResultService<MealBaseVM> result = _mealBLL.GetAllMeal();

            if (!result.HasError)
            {
                string[] mealNames = result.ListData.Select(x => x.MealName).ToArray();

                lstMeal.Items.AddRange(mealNames);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MealCreateVM vm = new MealCreateVM()
            {
                MealName = txtMealName.Text,                
            };
            ResultService<Meal> result = _mealBLL.CreateMeal(vm);
            GetResult(result);
            FillWithList();            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string mealName = lstMeal.SelectedItem.ToString();
            ResultService<Meal> result = _mealBLL.GetMeal(mealName);

            if (!result.HasError)
            {
                MealUpdateVM vm = new MealUpdateVM()
                {
                    MealName = txtMealName.Text,
                    Id = result.Data.ID,
                };
                ResultService<MealUpdateVM> updateResult = _mealBLL.UpdateMeal(vm);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int mealName = lstMeal.SelectedIndex;
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            if (!result.HasError)
            {
                MealBaseVM @base = new MealBaseVM()
                {
                    Id = result.Data.Id
                };
                ResultService<MealBaseVM> baseResult = _mealBLL.DeleteMeal(@base.Id);
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

        private void GetResult(ResultService<Meal> result)
        {
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.FirstOrDefault().ErrorMessage;
                string errorType = result.ErrorItems.FirstOrDefault()?.ErrorType;
                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstMeal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mealName = lstMeal.SelectedItem.ToString();
            txtMealName.Text = _mealBLL.GetMeal(mealName).Data.MealName;
        }
    }
}
