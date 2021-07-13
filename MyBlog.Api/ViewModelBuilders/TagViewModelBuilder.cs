using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBlog.Api.ViewModels;
using MyBlog.Domain;

namespace MyBlog.Api.ViewModelBuilders
{
    public static class TagViewModelBuilder
    {
        public static TagViewModel Build(Tag tag)
        {
            return new TagViewModel
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static IEnumerable<TagViewModel> Build(List<ArticleTag> articleTags)
        {
            return articleTags.Select(x => Build(x.Tag));
        }
    }
}
