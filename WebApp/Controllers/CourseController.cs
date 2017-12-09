using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: Course
        public ActionResult Index()
        {
            var allCourses = _courseRepository.GetAll();
            return View();
        }

        public ActionResult ViewCourse(int courseId)
        {
            var course = _courseRepository.GetSingle(c => c.Id == courseId, c => c.Elements);
            return View(course);
        }
    }
}