using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace holidayresort.Controllers
{
    public class LandingPage : Controller
    {
        public SelectList placeGet()
        {
            var reservationtypes = new List<string>
            {
                "Kosmos",
                "Mount Amanzi",
                "SchomasVille"
            };

            return new SelectList(reservationtypes);
        }
        // GET: LandingPage
        public ActionResult Index()
        {
            ViewBag.placeList = placeGet();
            return View();
        }

        // GET: LandingPage/Details/5   
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LandingPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandingPage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LandingPage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LandingPage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LandingPage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LandingPage/Delete/5
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
    }
}
