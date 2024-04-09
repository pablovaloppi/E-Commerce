namespace E_Commerce.Responses
{
    public class Response
    {
        public Response() { }
        public Response(int statusCode = 0, string message = null, object data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; } = null!;
        public object Data { get; set; } = null!;
    }
}
