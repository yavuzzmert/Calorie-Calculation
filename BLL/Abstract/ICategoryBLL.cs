using Entities;
using Systm;
using ViewModels.CategoryViewModels;

namespace BLL.Abstract
{
    public interface ICategoryBLL : IBaseBLL<Category>
    {
        ResultService<CategoryBaseVM> GetCategoryId(string categoryName);
        ResultService<Category> GetAllCategories();
        ResultService<Category> GetCategoryByName(string categoryName);
        ResultService<CategoryBaseVM> DeleteCategoryById(int id);
        ResultService<CategoryUpdateVM> UpdateCategory(CategoryUpdateVM vm);
        ResultService<Category> CreateCategory(CategoryCreateVM vm);
        ResultService<CategoryUpdateVM> GetCategory(int id);
        bool AnyCategory(string categoryName);
    }
}
