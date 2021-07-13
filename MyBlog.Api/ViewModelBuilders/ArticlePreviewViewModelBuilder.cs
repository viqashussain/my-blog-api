using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using MyBlog.Api.ViewModels;
using MyBlog.Domain;

namespace MyBlog.Api.ViewModelBuilders
{
    public static class ArticlePreviewViewModelBuilder
    {
        public static IEnumerable<ArticlePreviewViewModel> Build(IEnumerable<Article> articles)
        {
            var enumeratedArticles = articles.ToList();
            return enumeratedArticles.Select(x => Build(x, enumeratedArticles));
        }

        public static ArticlePreviewViewModel Build(Article article, List<Article> articles)
        {
            var articleIndex = (articles.OrderByDescending(x => x.PublishDate).IndexOf(article));
            var pageNumber = (articleIndex / 3) + 1;
            return new ArticlePreviewViewModel
            {
                Id = article.Id,
                Title = article.Title,
                UrlTitle = article.UrlTitle,
                PreviewText = article.PreviewText,
                CreationDate = article.CreationDate,
                PublishDate = article.PublishDate,
                PreviewImageFileName = article.PreviewImageFileName,
                ThumbnailImageFileName = article.ThumbnailImageFileName,
                Category = CategoryViewModelBuilder.Build(article.ArticleCategory),
                Tags = TagViewModelBuilder.Build(article.ArticleTags),
                PageNumber = pageNumber
            };
        }
    }
}
