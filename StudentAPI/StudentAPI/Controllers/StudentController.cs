using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Vishali", Email = "123@gmail.com", Course = "C#" },
            new Student { Id = 2, Name = "Sam" , Email = "456@gmail.com", Course = "Java"},
            new Student { Id = 3, Name = "Shalini" , Email = "789@gmail.com", Course = "Python" }
        };

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"Student with Id {id} not found.");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            student.Id = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student updatedstudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"Student with Id {id} not found.");
            student.Name = updatedstudent.Name;
            student.Email = updatedstudent.Email;
            student.Course = updatedstudent.Course;
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s =>s.Id == id);
            if (student == null)
                return NotFound($"Student with Id {id} not found.");
            _students.Remove(student);
            return Ok($"Student [id] deleted sucessfully.");
        }

    }
}
