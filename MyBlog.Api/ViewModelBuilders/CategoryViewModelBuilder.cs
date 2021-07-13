using MyBlog.Api.ViewModels;
using MyBlog.Domain;

namespace MyBlog.Api.ViewModelBuilders
{
    public static class CategoryViewModelBuilder
    {
        public static CategoryViewModel Build(ArticleCategory category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
