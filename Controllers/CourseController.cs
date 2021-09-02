using AZWebAppDB.Models;
using AZWebAppDB.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWebAppDB.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;
        public CourseController(CourseService CS)
        {
            courseService = CS;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> _courselist = courseService.GetCourses();
            return View(_courselist);
        }
    }
}
