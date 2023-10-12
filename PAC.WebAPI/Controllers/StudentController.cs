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
        public IActionResult CreateStudent([FromBody] StudentModelRequest studentDto)
        {
            Student parsedStudent = studentDto.ToEntity();
            StudentLogic.InsertStudents(parsedStudent);
            return Created($"api/users/{parsedStudent.Id}", parsedStudent);
        }

    }
}
