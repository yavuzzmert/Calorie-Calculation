using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Systm;
using ViewModels.CategoryViewModels;

namespace BLL.Concrete
{
    public class CategoryService : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public bool AnyCategory(string categoryName)
        {
            bool validCategory = _categoryDAL.GetAll(x => x.IsActive).Any(x => x.CategoryName.Equals(categoryName));
            return validCategory;
        }

        public ResultService<Category> CreateCategory(CategoryCreateVM vm)
        {
            ResultService<Category> result = new ResultService<Category>();
            bool checkCategory = AnyCategory(vm.CategoryName);
            if (!checkCategory)
            {
                Category newCategory = new Category()
                {
                    CategoryName = vm.CategoryName,
                    CreateOn= vm.CreateDate
                };
                Category addCategory = _categoryDAL.Add(newCategory);
                result.Data = addCategory ?? newCategory;
                if (addCategory == null)
                {
                    result.AddError("Hata Oluştu", "Ekleme İşlemi Başarısız.");
                }
            }
            else
            {
                result.Data = new Category
                {
                    CategoryName = vm.CategoryName
                };
                result.AddError("Kayıt mevcut", "Ekleme Başarısız");
            }
            return result;
        }

        public ResultService<CategoryBaseVM> DeleteCategoryById(int id)
        {
            ResultService<CategoryBaseVM> result= new ResultService<CategoryBaseVM>();
            try
            {
                Category category = _categoryDAL.Get(x => x.ID.Equals(id) && x.IsActive);
                category.IsActive = false;
                _categoryDAL.Delete(category);

                result.Data = new CategoryBaseVM
                {
                    Id = category.ID,
                    Name = category.CategoryName
                };
            }
            catch (Exception)
            {

                result.AddError("Silme İşlemi Başarısız.", "Kayıt BUlunamadı.");
            }
            return result;
        }

        public ResultService<Category> GetAllCategories()
        {
            ResultService<Category> result = new ResultService<Category>();
            List<Category> categories = _categoryDAL.GetAll(x => x.IsActive, /*x => x.CategoryName,*/x=>x.Foods).ToList();
            result.ListData = categories;
            return result;
        }

        public ResultService<CategoryUpdateVM> GetCategory(int id)
        {
            ResultService<CategoryUpdateVM> result = new ResultService<CategoryUpdateVM>();

            Category category = _categoryDAL.Get(x => x.ID == id && x.IsActive);
            if (category != null)
            {
                result.Data = new CategoryUpdateVM
                {
                    Id = category.ID,
                    Name = category.CategoryName
                };
            }
            else
            {
                result.AddError("Kayıt Bulunamadı.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<Category> GetCategoryByName(string categoryName)
        {
            ResultService<Category> result = new ResultService<Category>();
            Category category = _categoryDAL.Get(x => x.IsActive && x.CategoryName == categoryName);
            if (category!=null)
            {
                result.Data = category;
            }
            else
            {
                result.Data = new Category
                {
                    ID = -1,
                    CategoryName = categoryName
                };
                result.AddError("Kayıt Bulunamadı", "Bu isimde bir kategori mevcut değil");
            }
            return result;
        }

        public ResultService<CategoryBaseVM> GetCategoryId(string categoryName)
        {
            ResultService<CategoryBaseVM> result = new ResultService<CategoryBaseVM>();
            Category category = _categoryDAL.Get(x => x.IsActive && x.CategoryName == categoryName);
            if (category != null)
            {
                result.Data = new CategoryBaseVM
                {
                    Id = category.ID,
                    Name = categoryName
                };
            }
            else
            {
                result.Data = new CategoryBaseVM
                {
                    Id = -1,
                    Name = categoryName
                };
                result.AddError("Kayıt Bulunamadı", "Bu isimde bir kategori yok");
            }
            return result;
        }

        public ResultService<CategoryUpdateVM> UpdateCategory(CategoryUpdateVM vm)
        {
            ResultService<CategoryUpdateVM> result = new ResultService<CategoryUpdateVM>();
            Category category = _categoryDAL.Get(x => x.IsActive && x.ID == vm.Id);
            if (!AnyCategory(vm.Name))
            {
                category.CategoryName = vm.Name;
                category.UpdateOn = vm.UpdateDate;
                Category updateCategory = _categoryDAL.Update(category);
                if (updateCategory != null)
                {
                    result.Data = new CategoryUpdateVM
                    {
                        Id = updateCategory.ID,
                        Name = updateCategory.CategoryName
                    };
                }
                else
                {
                    result.AddError("Hata", "Güncelleme Başarısız");
                }
            }

            else
            {
                result.Data = vm;
                result.AddError("Güncelleme Başarısız.", "Kayıt Bulunamadı.");
            }

            return result;
        }
    }
}
