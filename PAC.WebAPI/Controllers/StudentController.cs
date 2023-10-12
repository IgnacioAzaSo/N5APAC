using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        public readonly IStudentLogic StudentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            StudentLogic = studentLogic;    
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult CreateStudent([FromBody] StudentModelRequest studentDto)
        {
            Student parsedStudent = studentDto.ToEntity();
            StudentLogic.InsertStudents(parsedStudent);
            return Created($"api/users/{parsedStudent.Id}", parsedStudent);
        }

        [HttpGet]
        public IActionResult GetAllStudents(int? age)
        {
            var students = StudentLogic.GetStudents();

            // Esta parte se validaria en el servicio. Por temas de tiempo se hace aca
            if (age.HasValue)
            {
                students = students.Where(student => student.Age == age.Value).ToList();
            }

            return Ok(students);
        }

        [HttpGet]
        public IActionResult GetStudentById([FromBody] int studentId)
        {
            Student students = StudentLogic.GetStudentById(studentId);
            return Ok(students);
        }
    }
}
