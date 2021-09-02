using AZWebAppDB.Models;
using AZWebAppDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWebAppDB.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;
        private readonly IConfiguration iconfiguration;
        public CourseController(CourseService CS, IConfiguration config)
        {
            courseService = CS;
            iconfiguration = config;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> _courselist = courseService.GetCourses(iconfiguration.GetConnectionString("SQLConnection"));
            return View(_courselist);
        }
    }
}
