using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApp.ViewModels;

namespace WebApplicationApp.Controllers
{
    public class WorkShiftsController(IWorkShiftApiClient workShiftApiClient) : Controller
    {
        private readonly IWorkShiftApiClient workShiftApiClient = workShiftApiClient;
      
      

        // GET: WorkShifts
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await workShiftApiClient.GetWorkShifts();
                return View(data);
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving work shifts.";
                ViewBag.ExceptionMessage = ex.Message;
                return View("Error");
            }
        }

        // GET: WorkShifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Please enter id";
                return RedirectToAction(nameof(Index));
                
            }

            var workShift = await workShiftApiClient.GetWorkShift(id.Value);
            if (workShift == null)
            {
                TempData["error"] = "Work shift not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(workShift);
        }

        // GET: WorkShifts/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] WorkShiftViewModel workShift)
        {
            if (!ModelState.IsValid) { return View(workShift); }
           var result = await workShiftApiClient.AddWorkShift(workShift);
            if(result)
            {
                TempData["Message"] = "Work Shift added successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = "Failed to add work shift.";
                return View(workShift);
            }
            
        }

        // GET: WorkShifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                string alertMessage = "Please enter id";
                ViewBag.AlertMessage = alertMessage;
                return PartialView("_AlertPartial");
            }

            var workShift = await workShiftApiClient.GetWorkShift(id.Value);
            var data = new WorkShiftRequest
            {
                ShiftID = workShift.ShiftID,
                NameShift = workShift.NameShift,
                DescriptionShift = workShift.DescriptionShift,
                StartTime = workShift.StartTime,
                EndTime = workShift.EndTime
            };
            return View(data);
        }

       
        [HttpPost]
     
        public async Task<IActionResult> Edit( [FromForm] WorkShiftViewModel request)
        {
        

            if (ModelState.IsValid) { return View(request); }
            var result = await workShiftApiClient.UpdateWorkShift(request);
            if(result)
            {
                TempData["success"] = "Work Shift updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Failed to update work shift.";
                return View(request);
            }
            
        }

        // GET: WorkShifts/Delete/5
        public  IActionResult Delete(int id)
        {
            TempData["success"] = "Delete success";
            return View(new WorkShiftDeleteRequest()
            {
                Id = id
                
            });

        }

        // POST: WorkShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(WorkShiftDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
           var result = await workShiftApiClient.DeleteWorkShift(request.Id);
            if (result)
            {
                TempData["Message"] = "Work Shift deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = "Failed to delete work shift.";
                return View(request);
            }
        }

       
    }
}
