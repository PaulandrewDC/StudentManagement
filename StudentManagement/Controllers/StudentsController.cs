using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Models.Entities;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var allStudents = dbContext.Students.ToList();

            return Ok(allStudents);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = dbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddStudents addStudents)
        {
            var studentEntity = new Student()
            {
                Name = addStudents.Name,
                Email = addStudents.Email,
                Phone = addStudents.Phone,
                Course = addStudents.Course
            };


            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateStudent(Guid id, UpdateStudent updateStudent)
        {
            var student = dbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            student.Name = updateStudent.Name;
            student.Email = updateStudent.Email;
            student.Phone = updateStudent.Phone;
            student.Course = updateStudent.Course;

            dbContext.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = dbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();

            return Ok();

        }
    }
}
