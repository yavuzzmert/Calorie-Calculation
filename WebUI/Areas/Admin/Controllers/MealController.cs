using BLL.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Systm;
using ViewModels.MealViewModels;

namespace Online2.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MealController : Controller
    {
        private readonly IMealBLL _mealBLL;
        public MealController(IMealBLL mealBLL)
        {
            _mealBLL = mealBLL;
        }

        // GET: MealController
        public ActionResult Index()
        {
            ResultService<MealBaseVM> result = _mealBLL.GetAllMeal();
            return View(result);
        }

        // GET: MealController/Details/5
        public ActionResult Details(int id)
        {
            //=_mealBLL.GetMeal(id);
            return View();
        }

        // GET: MealController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreateVM vm)
        {
            ResultService<Meal> result = _mealBLL.CreateMeal(vm);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorType;

                ViewData["Errors"] = errorMessage + "\n" + errorType;
                return View(vm); // Hata ile birlikte ilgili gelen veriyi de geri döndürecek.
            }
            TempData["Success"] = result.Data.MealName + "\n" + "Kayıt işlemi başarılı";
            return RedirectToAction("Index");
        }

        // GET: MealController/Edit/5
        public ActionResult Update(int id)
        {
            ResultService<Meal> result = _mealBLL.GetMeal(id);
            MealUpdateVM updateVM = new MealUpdateVM()
            {
                Id = result.Data.ID,
                MealName = result.Data.MealName,
            };

            return View(updateVM);
        }

        // POST: MealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MealUpdateVM vm)
        {
            ResultService<MealUpdateVM> result = _mealBLL.UpdateMeal(vm);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorType;

                ViewData["Errors"] = errorMessage + "\n" + errorType;
                return View(vm);
            }
            TempData["Success"] = result.Data.MealName + "\n" + "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        // GET: MealController/Delete/5
        public ActionResult Delete(int id)
        {
            ResultService<MealBaseVM> result = _mealBLL.DeleteMeal(id);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorType;

                TempData["Errors"] = errorMessage + "\n" + errorType;
            }
            else
            {
                string message = "Silme işlemi başarılı";
                string deletedName = result.Data.MealName;

                TempData["Success"] = message + " " + deletedName;
            }
            return RedirectToAction("Index");
        }


    }
}
