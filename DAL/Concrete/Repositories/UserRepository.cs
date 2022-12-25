using DAL.Abstract;
using DAL.Base.EntityFrameWork;
using DAL.Concrete.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repositories
{
    public class UserRepository : EFRepositoryBase<User, DietDBContext>, IUserDAL
    {
        public UserRepository(DietDBContext db) : base(db)
        {
        }
    }
}
