using BLL.Abstract;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Systm;
using ViewModels.FoodViewModels;

namespace BLL.Concrete
{
	public class FoodService : IFoodBLL
	{
		private readonly IFoodDAL _foodDAL;

		public FoodService(IFoodDAL foodDAL)
		{
			_foodDAL = foodDAL;
		}

		public bool AnyFood(string foodName)
		{
			bool validFood = _foodDAL.GetAll(x => x.IsActive).Any(x => x.FoodName.Equals(foodName));
			return validFood;
		}

		public ResultService<Food> CreateFood(FoodCreateVM vm)
		{
			ResultService<Food> result = new ResultService<Food>();

			bool checkFood = AnyFood(vm.FoodName);
			if (!checkFood)
			{
				Food newFood = new Food()
				{
					FoodName = vm.FoodName,
					CreateOn = vm.CreateOn,
					Calorie = vm.Calorie,
				};

				Food addFood = _foodDAL.Add(newFood);

				result.Data = addFood ?? newFood;

				if(addFood == null)
				{
					result.AddError("Ekleme hatası", "Ekleme işlemi başarısız");
				}
			}
			else
			{
				result.Data = new Food
				{
					FoodName = vm.FoodName,
				};
				result.AddError("Yemek zaten mevcut!", "Ekleme başarısız!");
			}
			return result;
		}

		public ResultService<FoodBaseVM> DeleteFood(int id)
		{
			ResultService<FoodBaseVM> result = new ResultService<FoodBaseVM>();
			try
			{
				Food food = _foodDAL.Get(x => x.IsActive && x.ID.Equals(id));
				food.IsActive = false;
				result.Data = new FoodBaseVM()
				{
					FoodName = food.FoodName,
				};
				_foodDAL.Delete(food);
			}
			catch (Exception)
			{
				result.AddError("Silme işlemi başarısız", "Kayıt bulunamadı.");
			}
			return result;
		}

		public ResultService<FoodBaseVM> GetAllFood()
		{
			ResultService<FoodBaseVM> result = new ResultService<FoodBaseVM>();
			List<FoodBaseVM> baseList = _foodDAL.GetAll(x => x.IsActive)
												 .Select(x => new FoodBaseVM()
												 {
													 Id = x.ID,
													 FoodName = x.FoodName
												 }).ToList();
			if (baseList.Count > 0)
			{
				result.ListData = baseList;
			}
			else
			{
				result.AddError("Hata", "Verilere ulaşılamadı!");
			}

			return result;
		}

		public ResultService<Food> GetFood(int id)
		{
			ResultService<Food> result = new ResultService<Food>();
			result.Data = _foodDAL.Get(x => x.IsActive && x.ID == id);
			if(result.Data == null)
			{
				result.AddError("Hata","Kayıt bulunamadı");
			}
			return result;
		}

		public ResultService<Food> GetFood(string foodName)
		{
			ResultService<Food> result = new ResultService<Food>();
			result.Data = _foodDAL.Get(x => x.IsActive && x.FoodName.Equals(foodName));
            if (result.Data == null)
            {
                result.AddError("Hata", "Kayıt bulunamadı");
            }
            return result;
        }

		public ResultService<FoodUpdateVM> UpdateFood(FoodUpdateVM vm)
		{
			ResultService<FoodUpdateVM> result = new ResultService<FoodUpdateVM>();
			try
			{
				Food food = _foodDAL.Get(x => x.IsActive && x.ID.Equals(vm.Id));
				food.FoodName = vm.FoodName;
				food.UpdateOn = vm.UpdateOn;
				food.Calorie = vm.Calorie;
				Food updateFood = _foodDAL.Update(food);
				result.Data = vm;
			}
			catch (Exception)
			{
				result.Data = vm;
				result.AddError("Güncelleme başarısız", "Kayıt bulunamadı");
			}
			return result;
		}
	}
}
