using OnlineBookStoreWeb.Data;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreWeb.Models;

namespace OnlineBookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //get action method
        public IActionResult Create()
        {

            return View();
        }

        //post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)

        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {

                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            //creating a new record inside the database (create new category button) 
            if (ModelState.IsValid)

            {
                _db.Categories.Add(obj);
                _db.SaveChanges(); //  this command pushes the data into the database
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //get action method
        public IActionResult Edit(int ? id)
        {
            if(id == null || id==0) 
            { 
            return NotFound();
            }
            var categoryFromDb=_db.Categories.Find(id);
            // var categoryFromDbFirst = _db.Categories.FirstOrDefault();
            
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            
            
            return View (categoryFromDb);
        }

        //post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)

        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {

                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            //creating a new record inside the database (create new category button) 
            if (ModelState.IsValid)

            {
                _db.Categories.Update(obj);
                _db.SaveChanges(); //  this command pushes the data into the database
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

    

    //get action method
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        // var categoryFromDbFirst = _db.Categories.FirstOrDefault();

        if (categoryFromDb == null)
        {
            return NotFound();
        }


        return View(categoryFromDb);
    }

    //post action method
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)

    {
            var obj= _db.Categories.Find(id);
            if (obj == null)
            { 
                return NotFound();
            }
     
            _db.Categories.Remove(obj);
            _db.SaveChanges(); //  this command pushes the data into the database
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        

        

    }

}

    
}
