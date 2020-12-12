using System.Collections.Generic;
using CoreCRUDwithOracle.Interface;
using CoreCRUDwithOracle.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCRUDwithOracle.Controllers
{
    public class StudentController : Controller
    {
        IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        public ActionResult Index()
        {
            IEnumerable<Student> student = studentService.GetAllStudent();

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            studentService.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Student student = studentService.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            studentService.EditStudent(student);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Student student = studentService.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            studentService.DeleteStudent(student);
            return RedirectToAction(nameof(Index));
        }
    }
}