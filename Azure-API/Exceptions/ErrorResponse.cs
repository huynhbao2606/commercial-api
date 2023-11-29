namespace AzureAPI.Exceptions
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
        

        private string getDefaultMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request From Client",
                401 => "You Are Not Authorized",
                404 => "Resource Not Found",
                500 => "Sever Error",
                _ => null
            };
        }

        public ErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? getDefaultMessageFromStatusCode(statusCode);
        }
    }
}
