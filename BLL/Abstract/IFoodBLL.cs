using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systm;
using ViewModels.FoodViewModels;

namespace BLL.Abstract
{
	public interface IFoodBLL : IBaseBLL<Food>
	{
		ResultService<Food> CreateFood(FoodCreateVM vm);

		ResultService<FoodUpdateVM> UpdateFood(FoodUpdateVM vm);

		ResultService<FoodBaseVM> DeleteFood(int id);

		ResultService<Food> GetFood(int id);

		ResultService<Food> GetFood(string foodName);

		ResultService<FoodBaseVM> GetAllFood();
	}
}
