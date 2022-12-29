using BLL.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Systm;
using ViewModels.CategoryViewModels;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryBLL _categoryBLL;
		public CategoryController(ICategoryBLL categoryBLL)
		{
			_categoryBLL = categoryBLL;
		}

		// GET: CategoryController
		public ActionResult Index()
		{
			ResultService<CategoryBaseVM> result = new ResultService<CategoryBaseVM>();
			result.ListData = _categoryBLL.GetAllCategories().ListData.Select(x => new CategoryBaseVM
			{
				Id = x.ID,
				Name = x.CategoryName,
			}).ToList();
			return View(result.ListData);
		}

		// GET: CategoryController/Details/5
		public ActionResult Details(int id)
		{
			ResultService<CategoryUpdateVM> result = _categoryBLL.GetCategory(id);
			if (result.HasError)
			{
				ViewBag.ErrorMessage = result.ErrorItems.First().ErrorMessage;
				ViewBag.ErrorType = result.ErrorItems.First().ErrorType;
			}
			return View(result.Data);
		}

		// GET: CategoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CategoryCreateVM vm)
		{
			ResultService<Category> result = _categoryBLL.CreateCategory(vm);
			if (result.HasError)
			{
				ViewBag.ErrorMessage = result.ErrorItems.First().ErrorMessage;
				ViewBag.ErroType = result.ErrorItems.First().ErrorType;
				return View(vm);
			}
			TempData["Success"] = "Kayıt Başarılı.";
			return RedirectToAction(nameof(Index));

		}

		// GET: CategoryController/Edit/5
		public ActionResult Edit(int id)
		{
			ResultService<CategoryUpdateVM> result = _categoryBLL.GetCategory(id);
			if (result.HasError)
			{
				ViewData["ErrorMessage"] = result.ErrorItems.First().ErrorMessage;
				ViewData["ErrorType"] = result.ErrorItems.First().ErrorType;
			}
			return View(result.Data);
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CategoryUpdateVM vm)
		{
			ResultService<CategoryUpdateVM> result = _categoryBLL.UpdateCategory(vm);
			if (result.HasError)
			{
                ViewData["ErrorMessage"] = result.ErrorItems.First().ErrorMessage;
                ViewData["ErrorType"] = result.ErrorItems.First().ErrorType;
				return View(vm);
            }
			TempData["Success"] = "Güncelleme Başarılı";

			return RedirectToAction(nameof(Index));
		}

		// GET: CategoryController/Delete/5
		public ActionResult Delete(int id)
		{
			ResultService<CategoryBaseVM> result = _categoryBLL.DeleteCategoryById(id);
			if (result.HasError)
			{
				TempData["ErrorMessage"] = result.ErrorItems.First().ErrorMessage;
				TempData["ErrorType"] = result.ErrorItems.First().ErrorType;
				return RedirectToAction("Index");
			}
			TempData["Success"] = "Silme işlemi başarılı.";
			return RedirectToAction("Index");
		}
		/*
		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
		*/
	}
}
