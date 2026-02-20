namespace Hms.Domain.Common
{
    public class Response
    {
        public int? Code { get; set; } = null;
        public bool Success { get; set; } = false;
        public string Message { get; set; } = " ";
        public object? Data { get; set; }
        public int? Pagination { get; set; } = null;

    }
}
