using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("erorr/{code}")]
    [ApiExplorerSettings(IgnoreApi=true)]
    public class ErorrController:BaseApiController
    {
     public IActionResult Erorr(int code){
        return new ObjectResult(new ApiResponse(code));
     }   
    }
}