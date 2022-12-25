using Entities;
using Systm;
using ViewModels.MealViewModels;

namespace BLL.Abstract
{
    public interface IMealBLL : IBaseBLL<Meal>
    {
        ResultService<Meal> CreateMeal(MealCreateVM vm);
        ResultService<MealUpdateVM> UpdateMeal(MealUpdateVM vm);
        ResultService<MealBaseVM> DeleteMeal(int id);
        ResultService<Meal> GetMeal(int id);
        ResultService<Meal> GetMeal(string mealName);
        ResultService<MealBaseVM> GetAllMeal();
    }
}
