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
    public class ArticlePreviewController : Controller
    {
        readonly GetAllEntitiesQuery getAllEntitiesQuery;
        readonly GetEntityByIdQuery getEntityByIdQuery;
        readonly GetArticlesByTagQuery getArticlesByTagQuery;
        readonly GetArticlesByCategoryQuery getArticlesByCategoryQuery;

        public ArticlePreviewController(GetAllEntitiesQuery getAllEntitiesQuery, 
            GetEntityByIdQuery getEntityByIdQuery, 
            GetArticlesByTagQuery getArticlesByTagQuery, 
            GetArticlesByCategoryQuery getArticlesByCategoryQuery)
        {
            this.getAllEntitiesQuery = getAllEntitiesQuery;
            this.getEntityByIdQuery = getEntityByIdQuery;
            this.getArticlesByTagQuery = getArticlesByTagQuery;
            this.getArticlesByCategoryQuery = getArticlesByCategoryQuery;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticlePreviewViewModel>> Get()
        {
            var articles = await getAllEntitiesQuery.Execute<Article>();
            var articleViewModels = ArticlePreviewViewModelBuilder.Build(articles);
            return articleViewModels;
        }

        [HttpGet("GetByHashTag/{id}")]
        public async Task<IEnumerable<ArticlePreviewViewModel>> GetByHashTag(int id)
        {
            var articles = await getArticlesByTagQuery.Execute(id);
            var articleViewModels = ArticlePreviewViewModelBuilder.Build(articles);
            return articleViewModels;
        }

        [HttpGet("GetByCategory/{id}")]
        public async Task<IEnumerable<ArticlePreviewViewModel>> GetByCategory(int id)
        {
            var articles = await getArticlesByCategoryQuery.Execute(id);
            var articleViewModels = ArticlePreviewViewModelBuilder.Build(articles);
            return articleViewModels;
        }
    }
}
