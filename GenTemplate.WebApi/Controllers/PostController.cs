using System.Threading.Tasks;
using GenTemplate.Application.Features.Post.GetPost;
using Microsoft.AspNetCore.Mvc;

namespace GenTemplate.WebApi.Controllers
{
    public class PostController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            //var errores = new List<string>()
            //{
            //    "xd"
            //};

            //throw new BadRequestException(errores);

            var query = new GetPostContract.Query();
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
