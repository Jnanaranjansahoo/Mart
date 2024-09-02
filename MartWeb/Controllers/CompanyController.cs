using Mart.DataAcess.Data;
using Mart.DataAcess.Repository.IRepository;
using Mart.Models;
using Microsoft.AspNetCore.Mvc;

namespace MartWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitofwork ;
        public CompanyController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitofwork.Company.GetAll().ToList();
            return View(objCompanyList);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company obj)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Company.Add(obj);
                _unitofwork.Save();
                TempData["success"] = "Company Created Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company? companyFromDb = _unitofwork.Company.Get(u => u.Id == id);

            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Company obj)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Company.Update(obj);
                _unitofwork.Save();
                TempData["success"] = "Company Update Successfully";
                return RedirectToAction("Index", "Company");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company? companyFromDb = _unitofwork.Company.Get(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Company? obj = _unitofwork.Company.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitofwork.Company.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = "Company Delete Successfully";
            return RedirectToAction("Index", "Company");
        }
    }
}
