using BLL.Abstract;
using Entities;
using System.Data;
using Systm;
using ViewModels.CategoryViewModels;

namespace WinUI.AdminForms.CategoryForm
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryBLL _categoryBLL;

        public FrmCategory(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            FillWithList();
        }

        private void FillWithList()
        {
             lstCategory.Items.Clear();
            ResultService<Category> result = _categoryBLL.GetAllCategories();

            if (!result.HasError)
            {
                string[] categoryNames = result.ListData.Select(x => x.CategoryName).ToArray();

                lstCategory.Items.AddRange(categoryNames);
            }
        }

        private void SelectedIndex(object sender, EventArgs e)
        {
            string categoryName = lstCategory.SelectedItem.ToString();
            txtCategoryName.Text = _categoryBLL.GetCategoryId(categoryName).Data.Name;
        }

        private void Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();

            switch(tag)
            {
                case "Create": 
                        CreateCategory();
                    break;
                case "Update":
                        UpdateCategory();
                    break;
                case "Delete":
                        DeleteCategory();
                    break;
            }
        }

        private void DeleteCategory()
        {
            string categoryName = lstCategory.SelectedItem as string;
            ResultService<Category> result = _categoryBLL.GetCategoryByName(categoryName);

            if (!result.HasError)
            {
                CategoryBaseVM @base = new CategoryBaseVM()
                {
                    Id = result.Data.ID,
                };
                ResultService<CategoryBaseVM> baseResult = _categoryBLL.DeleteCategoryById(@base.Id);
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

        private void UpdateCategory()
        {
            string categoryName = lstCategory.SelectedItem as string;
            ResultService<Category> result = _categoryBLL.GetCategoryByName(categoryName);

            if (!result.HasError)
            {
                CategoryUpdateVM vm = new CategoryUpdateVM()
                {
                    Name = txtCategoryName.Text,
                    Id = result.Data.ID,
                };
                ResultService<CategoryUpdateVM> updateResult = _categoryBLL.UpdateCategory(vm);
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

        private void CreateCategory()
        {
            CategoryCreateVM vm = new CategoryCreateVM()
            {
                CategoryName = txtCategoryName.Text,
            };

            ResultService<Category> result = _categoryBLL.CreateCategory(vm);
            GetResult(result);
            FillWithList();
        }

        private void GetResult(ResultService<Category> result)
        {
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.FirstOrDefault().ErrorMessage;
                string errorType = result.ErrorItems.FirstOrDefault().ErrorType;

                MessageBox.Show(errorMessage,errorType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
