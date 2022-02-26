using Microsoft.AspNetCore.Mvc;
using StudentRecordManagementApp.Models;
using StudentRecordManagementApp.Services;

namespace StudentRecordManagementApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;
        public StudentsController(IConfiguration configuration, IStudentService studentService)
        {
            _configuration = configuration;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentsList()
        {
            AllModels model = new()
            {
                StudentsList = _studentService.GetStudentsList().ToList()
            };

            return View(model);
        }
    }
}
