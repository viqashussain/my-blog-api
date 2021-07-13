using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.ViewModelBuilders;
using MyBlog.Api.ViewModels;
using MyBlog.CommandQuery.Queries;
using MyBlog.Domain;

namespace MyBlog.Api.Controllers
{
    [Route("api/[controller]")]
    public class AboutMeController : Controller
    {
        private GetAboutMeDataQuery getAboutMeDataQuery;

        public AboutMeController(GetAboutMeDataQuery getAboutMeDataQuery)
        {
            this.getAboutMeDataQuery = getAboutMeDataQuery;
        }

        [HttpGet]
        public async Task<AboutMeViewModel> Get()
        {
            var aboutMeData = await getAboutMeDataQuery.Execute();
            var viewModel = AboutMeViewModelBuilder.Build(aboutMeData);
            return viewModel;
        }
    }
}
