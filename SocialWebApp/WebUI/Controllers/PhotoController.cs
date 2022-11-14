using Application.Photos.Queries.GetPhotoByUserQuery;
using Application.Posts.Queries.GetPersonalPosts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class PhotoController : ApiControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<ActionResult<PhotoVm>> GetUserPhotos(int userId, int offset = 0, int limit = 100)
        {
            return await Mediator.Send(new GetPhotoByUserQuery(userId, offset, limit));
        }
    }
}
