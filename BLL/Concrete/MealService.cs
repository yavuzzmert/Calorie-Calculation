using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Systm;
using ViewModels.MealViewModels;

namespace BLL.Concrete
{
    public class MealService : IMealBLL
    {
        private readonly IMealDAL _mealDAL;
        public MealService(IMealDAL mealDAL)
        {
            _mealDAL = mealDAL;
        }
        public bool AnyMeal(string mealName)
        {
            bool validMeal = _mealDAL.GetAll(x => x.IsActive).Any(x => x.MealName.Equals(mealName));
            return validMeal;
        }
        public ResultService<Meal> CreateMeal(MealCreateVM vm)
        {
            ResultService<Meal> result = new ResultService<Meal>();
            bool checkMeal = AnyMeal(vm.MealName);
            if (!checkMeal)
            {
                Meal newMeal = new Meal()
                {
                    MealName = vm.MealName,
                    CreateOn = vm.CreateOn,
                };
                Meal addMeal = _mealDAL.Add(newMeal);

                result.Data = addMeal ?? newMeal;

                if (addMeal == null)
                {
                    result.AddError("Ekleme Hatası", "Ekleme İşlemi Başarısız.");
                }
            }
            else
            {
                result.Data = new Meal
                {
                    MealName = vm.MealName,
                };
                result.AddError("Öğün zaten var!", "Ekleme Başarısız!");
            }
            return result;
        }
        public ResultService<MealUpdateVM> UpdateMeal(MealUpdateVM vm)
        {
            ResultService<MealUpdateVM> result = new ResultService<MealUpdateVM>();
            try
            {
                Meal meal = _mealDAL.Get(x => x.IsActive && x.ID.Equals(vm.Id));
                meal.MealName = vm.MealName;
                meal.UpdateOn = vm.UpdateOn;
                Meal updateMeal = _mealDAL.Update(meal);
                result.Data = vm;
            }
            catch (Exception)
            {

                result.Data = vm;
                result.AddError("Güncelleme Başarısız.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<MealBaseVM> DeleteMeal(int id)
        {
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            try
            {
                Meal meal = _mealDAL.Get(x => x.IsActive && x.ID.Equals(id));
                meal.IsActive = false;
                result.Data = new MealBaseVM()
                {
                    MealName = meal.MealName,
                };
                _mealDAL.Delete(meal);
            }
            catch (Exception)
            {
                result.AddError("Silme İşlemi Başarısız.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<MealBaseVM> GetAllMeal()
        {
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            List<MealBaseVM> baseList = _mealDAL.GetAll(x => x.IsActive)
                                                .Select(x => new MealBaseVM()
                                                {
                                                    Id = x.ID,
                                                    MealName = x.MealName
                                                }).ToList();
            if (baseList.Count > 0)
                result.ListData = baseList;
            else
                result.AddError("Hata", "Verilere Ulaşılamadı!");

            return result;
        }

        public ResultService<Meal> GetMeal(int id)
        {
            ResultService<Meal> result = new ResultService<Meal>();
            result.Data = _mealDAL.Get(x => x.IsActive && x.ID == id);
            if (result.Data == null)
                result.AddError("Hata", "Kayıt Bulunamadı.");
            return result;
        }

        public ResultService<Meal> GetMeal(string mealName)
        {
            ResultService<Meal> result = new ResultService<Meal>();
            result.Data = _mealDAL.Get(x => x.IsActive && x.MealName.Equals(mealName));
            if (result.Data == null)
                result.AddError("Hata", "Kayıt Bulunamadı.");
            return result;

        }


    }
}
