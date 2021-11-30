using CCAS.MVC.Interfaces;
using CCAS.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCAS.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: CoursesController
        public async Task<ActionResult> Index()
        {
            var model = await _courseService.GetCourses();
            return View(model);
        }

        // GET: CoursesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _courseService.GetCourseDetails(id);

            return View(model);
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCourseVM course)
        {
            try
            {
                var response = await _courseService.CreateCourse(course);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(course);
        }

        // GET: CoursesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _courseService.GetCourseDetails(id);

            return View(model);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CourseVM course)
        {
            try
            {
                var response = await _courseService.UpdateCourse(id, course);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(course);
        }

        // GET & POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _courseService.DeleteCourse(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}
