using DAL.Abstract;
using DAL.Base.EntityFrameWork;
using DAL.Concrete.Context;
using Entities;

namespace DAL.Concrete.Repositories
{
    public class CategoryRepository : EFRepositoryBase<Category, DietDBContext>, ICategoryDAL
    {
        public CategoryRepository(DietDBContext db) : base(db)
        {
        }
    }
}
