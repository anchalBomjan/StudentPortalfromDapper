using Microsoft.AspNetCore.Mvc;
using StudentPortalfromDapper.Models;
using StudentPortalfromDapper.Repositories;

namespace StudentPortalfromDapper.Controllers
{
    public class StudentsController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentModel viewModel)
        {
           

            await _studentRepository.AddStudentAsync(viewModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _studentRepository.GetStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentModel viewModel)
        {
            var student = await _studentRepository.GetStudentByIdAsync(viewModel.ID);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Subscribed = viewModel.Subscribed;

            await _studentRepository.UpdateStudentAsync(student);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentRepository.DeleteStudentAsync(id);
            return Redirect("List");
        }
    }
}