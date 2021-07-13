using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.ViewModelBuilders;
using MyBlog.Api.ViewModels;
using MyBlog.CommandQuery.Queries;
using MyBlog.Domain;

namespace MyBlog.Api.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        readonly GetAllEntitiesQuery getAllEntitiesQuery;
        readonly GetEntityByIdQuery getEntityByIdQuery;
        readonly GetArticlesByTagQuery getArticlesByTagQuery;
        readonly GetArticlesByCategoryQuery getArticlesByCategoryQuery;

        public ArticleController(GetAllEntitiesQuery getAllEntitiesQuery,
            GetEntityByIdQuery getEntityByIdQuery,
            GetArticlesByTagQuery getArticlesByTagQuery,
            GetArticlesByCategoryQuery getArticlesByCategoryQuery)
        {
            this.getAllEntitiesQuery = getAllEntitiesQuery;
            this.getEntityByIdQuery = getEntityByIdQuery;
            this.getArticlesByTagQuery = getArticlesByTagQuery;
            this.getArticlesByCategoryQuery = getArticlesByCategoryQuery;
        }

        [HttpGet("{id}")]
        public async Task<ArticleViewModel> Get(string id)
        {
            var allArticles = await getAllEntitiesQuery.Execute<Article>();
            var article = allArticles.First(x => x.UrlTitle == id);
            var articleViewModel = ArticleViewModelBuilder.Build(article);
            return articleViewModel;
        }
    }
}
