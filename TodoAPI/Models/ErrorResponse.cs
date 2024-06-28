namespace TodoAPI.Models
{
    public class ErrorResponse
    {
        public String Title { get; set; }
        public int StatusCode { get; set; }
        public String Message { get; set; }
    }
}