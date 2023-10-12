namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
        [TestInitialize]
        public void InitTest()
        {
        }

        [TestMethod]
        public void CreateUser_ReturnsCreatedStatusCode()
        {
 
            StudentModelRequest studentDto = new StudentModelRequest
            {
                Id = 1,
                Name = "Name"
            };

            
            var studentLogicMock = new Mock<IStudentLogic>();

            studentLogicMock.Setup(logic => logic.InsertStudents(It.IsAny<Student>()))
                .Callback<Student>(student =>
                {
                    student.Id = 1;
                    student.Name = "Name";
                });

            var controller = new StudentController(studentLogicMock.Object);

            var result = controller.CreateStudent(studentDto) as CreatedResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
            Assert.AreEqual(result.Location, "api/users/1"); 
        }

}
