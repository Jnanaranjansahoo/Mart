using MartWeb.Data;
using MartWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MartWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CompanyController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _db.Companies.ToList();
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
                _db.Companies.Add(obj);
                _db.SaveChanges();
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
            Company? companyFromDb = _db.Companies.Find(id);

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
                _db.Companies.Update(obj);
                _db.SaveChanges();
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
            Company? companyFromDb = _db.Companies.Find(id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Company? obj = _db.Companies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Companies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Company Delete Successfully";
            return RedirectToAction("Index", "Company");
        }
    }
}
