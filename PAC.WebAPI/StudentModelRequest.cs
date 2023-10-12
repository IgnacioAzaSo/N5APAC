using PAC.Domain;

namespace PAC.WebAPI
{
    public class StudentModelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student ToEntity()
        {
            return new Student()
            {
                Id = Id,
                Name = Name,
                Age = Age,
            };
        }
    }
}