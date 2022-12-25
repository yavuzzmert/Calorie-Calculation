using BLL.Abstract;
using BLL.Concrete;
using DAL;
using Microsoft.Extensions.DependencyInjection;


namespace BLL
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDal();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IMealBLL, MealService>();
            services.AddScoped<ICategoryBLL, CategoryService>();
            
        }
    }
}
