namespace API.Errors
{
    public class ApiValidationErorrResponse : ApiResponse
    {
        public IEnumerable<string> Erorrs{get;set;}
        public ApiValidationErorrResponse() : base(400)
        {
        }
    }
}