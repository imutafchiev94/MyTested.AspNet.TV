namespace Catstagram.Server.Features.Cats
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService) => this.catService = catService;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await this.catService.Create(
                model.ImageUrl, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }
    }
}
