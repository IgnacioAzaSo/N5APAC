using PAC.Domain;

namespace PAC.WebAPI
{
    public class StudentModelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student ToEntity()
        {
            return new Student()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}