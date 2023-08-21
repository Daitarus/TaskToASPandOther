namespace WebApplication1.Models
{
    public class Response
    {
        public bool isError { get; }
        public string? ErrorString { get; }
        public string? ResponseData { get; }
        public Response(bool isError, string errorString)
        {
            this.isError = isError;
            ErrorString = errorString;
        }
        public Response(string responseData)
        {
            this.ResponseData = responseData;
        }
    }
}
