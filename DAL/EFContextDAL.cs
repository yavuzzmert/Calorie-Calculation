using DAL.Abstract;
using DAL.Concrete.Context;
using DAL.Concrete.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace DAL
{
    public static class EFContextDAL
    {
        public static void AddScopeDal(this IServiceCollection services) 
        {
            services.AddDbContext<DietDBContext>()
                .AddScoped<ICategoryDAL, CategoryRepository>()
                .AddScoped<IFoodDAL, FoodRepository>()
                .AddScoped<IMealDAL, MealRepository>()
                .AddScoped<IUserDAL, UserRepository>()
                .AddScoped<IMealFoodDAL, MealFoodRepository>();
        }
    }
}
