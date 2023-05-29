namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message= null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefaultMessageForStatusCode(StatusCode);
        }

        

        public int StatusCode { get; set; }
        public string Message { get; set; }

private string GetDefaultMessageForStatusCode(int statusCode)
        {
          return  statusCode switch{
            400=>"A bad request,you have made",
            401=>"Authorized,you are not",
            404=>"Resource Found , it was not",
            500=>"Errors are the path to Dark side Errors Lead to anger . Anger leads to Hate leads to Carred Change",
            _=> null
          };
        }
    }
} 