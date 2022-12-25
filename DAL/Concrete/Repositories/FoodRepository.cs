using DAL.Abstract;
using DAL.Base.EntityFrameWork;
using DAL.Concrete.Context;
using Entities;

namespace DAL.Concrete.Repositories
{
    public class FoodRepository : EFRepositoryBase<Food, DietDBContext>, IFoodDAL
    {
        public FoodRepository(DietDBContext db) : base(db)
        {
        }
    }
}
