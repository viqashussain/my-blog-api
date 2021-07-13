using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBlog.Api.ViewModels;
using MyBlog.Domain;

namespace MyBlog.Api.ViewModelBuilders
{
    public static class AboutMeViewModelBuilder
    {
        public static AboutMeViewModel Build(AboutMeData aboutMeData)
        {
            return new AboutMeViewModel
            {
                HtmlContent = aboutMeData.HtmlContent
            };
        }
    }
}
