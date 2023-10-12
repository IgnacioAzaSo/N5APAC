namespace PAC.Domain
{
    public class ErrorDto
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}