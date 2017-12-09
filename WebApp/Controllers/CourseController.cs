using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Core.Services;
using WebApp.Database;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        private IComponentRepository _componentRepository;

        public CourseController(ICourseRepository courseRepository,
            IComponentRepository componentRepository)
        {
            _courseRepository = courseRepository;
            _componentRepository = componentRepository;
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

        public ActionResult ViewCourseConspect(string code)
        {
            var course = _courseRepository.GetSingle(c => c.UniqueCode == code, c => c.Elements);
            return View("ViewCourse", course);
        }

        [HttpPost]
        //[Authorize]
        public JsonResult AddComponent(SaveComponentResource model)
        {
            try
            {
                var comp = new Element()
                {
                    TextContent = model.TextContent,
                    BinaryContent = model.BinaryContent,
                    CreateDate = DateTime.Now,
                    LastChangedDate = DateTime.Now,
                    CursId = model.CursId,
                    Type = model.Type,
                };
                _componentRepository.Add(comp);
            }
            catch (Exception e)
            {
                return Json("error: " + e.Message, JsonRequestBehavior.DenyGet);
            }            

            return Json("success", JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        //[Authorize]
        public JsonResult GetComponent(int id)
        {
            try
            {
                var comp = _componentRepository.GetSingle(e => e.Id == id, e => e.course);
                var compRes = ObjectMapper.Convert(comp);                

                return Json(compRes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("error: " + e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}