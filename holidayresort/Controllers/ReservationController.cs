using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using NToastNotify;
using Service;

namespace holidayresort.Controllers
{
    public class ReservationController : Controller
    {
        private readonly DataHandler dataHandler;
        private readonly IToastNotification _toastNotification;
        public ReservationController(DataHandler handler, IToastNotification toastNotification)
        {
            dataHandler = handler;
            _toastNotification = toastNotification;
        }

        #region SelectList
        public SelectList RTypesGet()
        {
            var reservationtypes = new List<string>
            {
                "Manor House",
                "Cottage",
                "Camping"
            };

            return new SelectList(reservationtypes);
        }
        #endregion
        // GET: ReservationController
        public async Task<ActionResult> Index(string msg="" , bool isValid = false)
        {
            
            if (isValid)
            {
                _toastNotification.AddSuccessToastMessage(msg);
            }
            var reservationList =  await dataHandler.ReservationListGet();
            return View(reservationList);
        }

        // GET: ReservationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await dataHandler.ReservationGetSingle(id);

            return View(model);
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            ViewBag.RType = RTypesGet();
            var model = new Reservation()
            {
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(4),
            };
            return View(model);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reservation model)
        {
            bool isValid = true;
            string msg = $"Reservation created successful for {model.StartDate.ToString("yyyy/MM/dd")} to {model.EndDate.ToString("yyyy/MM/dd")}";
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ReservationType.Contains("-select-"))
                    {
                        isValid = false;
                        ModelState.AddModelError("ReservationType", $"Please populate Reservation Type");
                    }
                    if (model.EndDate < model.StartDate)
                    {
                        isValid = false;
                        msg = $"End date {model.EndDate.ToString("yyyy/MM/dd")} cannot be greater than Start date {model.StartDate.ToString("yyyy/MM/dd")}. Please correct";
                        ModelState.AddModelError("EndDate", msg);
                        //Error
                    }
                    if (!isValid)
                    {
                        ViewBag.RType = RTypesGet();
                        return View();
                    }

                    var r =  await dataHandler.AddReservation(model);
                    if (!r)
                    {
                        isValid = false;
                        msg = "Error occured during the process";
                        ModelState.AddModelError(string.Empty, msg);
                        //Error
                        return View();
                    }

                }
            }
            catch(Exception ex)
            {
                // ModelState.AddModelError(string.Empty, ex.Message);
                _toastNotification.AddErrorToastMessage(ex.Message);

            }
            return RedirectToAction("Index", new { msg = msg, isValid = isValid });
        }

        // GET: ReservationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.RType = RTypesGet();
            var model =  await dataHandler.ReservationGetSingle(id);

            return View(model);
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Reservation model)
        {
            bool isValid = true;
            string msg = "Updates where saved successful";
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ReservationType.Contains("-select-"))
                    {
                        isValid = false;
                        ModelState.AddModelError("ReservationType", $"Please populate Reservation Type");
                    }
                    if (model.EndDate < model.StartDate)
                    {
                        //Error
                        isValid = false;
                        msg = $"End date {model.EndDate.ToString("yyyy/MM/dd")} cannot be greater than Start date {model.StartDate.ToString("yyyy/MM/dd")}. Please correct";
                        ModelState.AddModelError("EndDate", msg);
                    }
                    if (!isValid)
                    {
                        ViewBag.RType = RTypesGet();
                        return View();
                    }

                    var r = await dataHandler.UpdateReservation(model);
                    if (!r)
                    {
                        msg = "Error occured during the process";
                        ModelState.AddModelError(string.Empty, msg);
                        //Error
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }
            return RedirectToAction("Index", new { msg = msg, isValid = isValid });
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
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
