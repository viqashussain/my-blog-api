using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.ViewModelBuilders;
using MyBlog.Api.ViewModels;
using MyBlog.CommandQuery.Queries;
using MyBlog.Domain;

namespace MyBlog.Api.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        readonly GetEntityByIdQuery getEntityByIdQuery;

        public TagController(GetEntityByIdQuery getEntityByIdQuery)
        {
            this.getEntityByIdQuery = getEntityByIdQuery;
        }

        [HttpGet("{id}")]
        public async Task<TagViewModel> Get(int id)
        {
            var tag = await getEntityByIdQuery.Execute<Tag>(id);
            var tagViewModel = TagViewModelBuilder.Build(tag);
            return tagViewModel;
        }
    }
}
