using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBlog.Api.ViewModels;
using MyBlog.Domain;

namespace MyBlog.Api.ViewModelBuilders
{
    public static class ArticleViewModelBuilder
    {
        public static IEnumerable<ArticleViewModel> Build(IEnumerable<Article> articles)
        {
            return articles.Select(Build);
        }

        public static ArticleViewModel Build(Article article)
        {
            return new ArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                UrlTitle = article.UrlTitle,
                CreationDate = article.CreationDate,
                PublishDate = article.PublishDate,
                Html = article.ArticleData.Html,
                ArticleImageFileName = article.ArticleData.ArticleImageFileName,
                ThumbnailImageFileName = article.ThumbnailImageFileName,
                Category = CategoryViewModelBuilder.Build(article.ArticleCategory),
                Tags = TagViewModelBuilder.Build(article.ArticleTags)
            };
        }
    }
}
