namespace MyAPI.Models
{
    public class Result<T>
    {
        public int StatusCode { get; set; }
        public string? StatusDescription { get; set; }
        public T? ResultData { get; set; }
    }
}
