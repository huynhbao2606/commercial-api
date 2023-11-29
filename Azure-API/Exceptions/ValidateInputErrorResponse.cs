namespace AzureAPI.Exceptions
{
    public class ValidateInputErrorResponse : ErrorResponse
    {
        public ValidateInputErrorResponse(int statusCode, string message = null) : base(statusCode,message){}

        public IEnumerable<string> Errors { get; set; }

    }
}
