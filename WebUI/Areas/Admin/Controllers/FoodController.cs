using BLL.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Systm;
using ViewModels.FoodViewModels;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodController : Controller
    {
        private readonly IFoodBLL _foodBLL;

        public FoodController(IFoodBLL foodBLL)
        {
            _foodBLL = foodBLL;
        }

        // GET: FoodController
        public ActionResult Index()
        {
            ResultService<FoodBaseVM> result = _foodBLL.GetAllFood();
            return View(result);
        }

        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            ResultService<Food> result = _foodBLL.GetFood(id);

            if (result.HasError)
            {
                ViewBag.ErrorMessage = result.ErrorItems.First().ErrorMessage;
                ViewBag.ErrorType = result.ErrorItems.First().ErrorType;
            }

            return View(result.Data);
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreateVM vm)
        {
            ResultService<Food> result = _foodBLL.CreateFood(vm);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorType;

                ViewData["Errors"] = errorMessage + "\n" + errorType;
                return View(vm); //hata ile birlikte gelen veriyi de geri döndürecek
            }
            TempData["Success"] = result.Data.FoodName + "\n" + "Kayıt işlemi başarılı";
            return RedirectToAction("Index");
        }

        // GET: FoodController/Edit/5
        public ActionResult Update(int id)
        {
            ResultService<Food> result = _foodBLL.GetFood(id);
            FoodUpdateVM updateVM = new FoodUpdateVM()
            {
                Id = result.Data.ID,
                FoodName = result.Data.FoodName,
                Calorie = result.Data.Calorie,
            };

            return View(updateVM);
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(FoodUpdateVM vm)
        {
            ResultService<FoodUpdateVM> result = _foodBLL.UpdateFood(vm);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorType;

                ViewData["Errors"] = errorMessage + "\n" + errorType;
                return View(vm);
            }
            TempData["Success"] = result.Data.FoodName + "\n" + "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            ResultService<FoodBaseVM> result = _foodBLL.DeleteFood(id);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorType;

                TempData["Errors"] = errorMessage + "\n" + errorType;
            }
            else
            {
                string message = "Silme işlemi başarılı";
                string deletedName = result.Data.FoodName;

                TempData["Success"] = message + " " + deletedName;
            }
            return RedirectToAction("Index");
        }
    }
}
