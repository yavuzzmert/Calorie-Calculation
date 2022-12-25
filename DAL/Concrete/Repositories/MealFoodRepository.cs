using DAL.Abstract;
using DAL.Base.EntityFrameWork;
using DAL.Concrete.Context;
using Entities;

namespace DAL.Concrete.Repositories
{
    public class MealFoodRepository : EFRepositoryBase<MealFood, DietDBContext>, IMealFoodDAL
    {
        public MealFoodRepository(DietDBContext db) : base(db)
        {
        }
    }
}
