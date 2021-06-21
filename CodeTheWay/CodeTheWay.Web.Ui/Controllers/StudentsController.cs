using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentsService StudentService;

        public StudentsController(IStudentsService studentsService)
        {
            this.StudentService = studentsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await StudentService.GetStudents());
        }

        public async Task<IActionResult> Create()
        {
            return View(new Student());
        }

        public async Task<IActionResult> Register(StudentRegisterViewModel model)
        {
            if (ModelState.IsValid && model.Age >= 18)
            {
                Student student = new Student()
                {
                    Id = model.Id,
                    LastName = model.LastName,
                    FirstMidName = model.FirstName
                };

                var result = await StudentService.Create(student);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await StudentService.GetStudent(id);

            return View(student);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var student = await StudentService.GetStudent(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> UpDate(Student model)
        {
            if (ModelState.IsValid)
            {
                var student = await StudentService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            await StudentService.Delete(student);
            return RedirectToAction("Index");
        }



    }
}
