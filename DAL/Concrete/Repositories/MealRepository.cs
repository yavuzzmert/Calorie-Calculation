using DAL.Abstract;
using DAL.Base.EntityFrameWork;
using DAL.Concrete.Context;
using Entities;

namespace DAL.Concrete.Repositories
{
    public class MealRepository : EFRepositoryBase<Meal, DietDBContext>, IMealDAL
    {
        public MealRepository(DietDBContext db) : base(db)
        {
        }
    }
}
