using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MyBlog.Api.Controllers;
using MyBlog.Api.ViewModels;
using MyBlog.Domain;
using MyBlog.EntityFramework;
using MyBog.Specs.Fakes;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MyBog.Specs.Steps
{
    [Binding]
    public class ArticleSteps
    {
        IEnumerable<ArticlePreviewViewModel> articlePreviewsControllerGetAllResponse;
        ArticleViewModel articlesControllerGetResponse;

        [Given(@"I have the following articles stored")]
        public void GivenIHaveTheFollowingArticlesStored(Table table)
        {
            var articlesToAdd = table.CreateSet<FakeArticle>();
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();

            dataContext.Articles.RemoveRange(dataContext.Articles.ToList());

            foreach (var fakeArticle in articlesToAdd)
            {
                var articleEntity = new Article
                {
                    Title = fakeArticle.Title,
                    CreationDate = fakeArticle.CreationDate,
                    PreviewText = fakeArticle.PreviewText,
                    PreviewImageFileName = fakeArticle.PreviewImageFileName,
                    ThumbnailImageFileName = fakeArticle.ThumbnailImageFileName,
                    PublishDate = fakeArticle.PublishDate,
                    ArticleCategory = dataContext.ArticleCategories.Single(x => x.Name == fakeArticle.CategoryName),
                    ArticleData = new ArticleData { Html = fakeArticle.Html, ArticleImageFileName = fakeArticle.ArticleImageFileName }
                };
                dataContext.Articles.AddRange(articleEntity);
            }
        }

        [Given(@"I have the following article tags stored")]
        public void GivenIHaveTheFollowingArticleTagsStored(Table table)
        {
            var articleTagsToAdd = table.CreateSet<Tag>();
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            dataContext.Tags.AddRange(articleTagsToAdd);
        }

        [Given(@"the article '(.*)' have the following tags")]
        public void GivenTheArticleHaveTheFollowingTags(string articleTitle, Table table)
        {
            var tags = table.CreateSet<Tag>();
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var article = dataContext.Articles.Single(x => x.Title == articleTitle);
            foreach (var articleTag in tags)
            {
                var articleTagEntity = new ArticleTag
                {
                    Tag = dataContext.Tags.Single(x => x.Name == articleTag.Name),
                    Article = article
                };
                article.ArticleTags.Add(articleTagEntity);
            }
        }

        [Given(@"I have the following article categories stored")]
        public void GivenIHaveTheFollowingArticleCategoriesStored(Table table)
        {
            var articleCategoriesToAdd = table.CreateSet<ArticleCategory>();
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            dataContext.ArticleCategories.AddRange(articleCategoriesToAdd);
        }

        [When(@"I retrieve a list of all the article previews")]
        public async Task WhenIRetrieveAListOfAllTheArticlePreviews()
        {
            var articleController = ApplicationTestContext.GetInstance<ArticlePreviewController>();
            articlePreviewsControllerGetAllResponse = await articleController.Get();
        }

        [When(@"I retrieve the article with title '(.*)'")]
        public async Task WhenIRetrieveTheArticleWithTitle(string articleTitle)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var urlTitle = dataContext.Articles.Single(x => x.Title == articleTitle).UrlTitle;
            var articleController = ApplicationTestContext.GetInstance<ArticleController>();
            articlesControllerGetResponse = await articleController.Get(urlTitle);
        }

        [When(@"I retrieve the articles with hashtag '(.*)'")]
        public async Task WhenIRetrieveTheArticlesWithHashtag(string hashtag)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var hashTagId = dataContext.Tags.Single(x => x.Name == hashtag).Id;
            var articlePreviewController = ApplicationTestContext.GetInstance<ArticlePreviewController>();
            articlePreviewsControllerGetAllResponse = await articlePreviewController.GetByHashTag(hashTagId);
        }

        [When(@"I retrieve the articles by category '(.*)'")]
        public async Task WhenIRetrieveTheArticlesByCategory(string categoryName)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var categoryId = dataContext.ArticleCategories.Single(x => x.Name == categoryName).Id;
            var articlePreviewController = ApplicationTestContext.GetInstance<ArticlePreviewController>();
            articlePreviewsControllerGetAllResponse = await articlePreviewController.GetByCategory(categoryId);
        }

        [Then(@"the following article previews should be returned")]
        public void ThenTheFollowingArticlePreviewsShouldBeReturned(Table table)
        {
            var expectedArticles = table.CreateSet<FakeArticle>();
            articlePreviewsControllerGetAllResponse.Should().HaveCount(expectedArticles.Count());

            foreach (var articleViewModel in articlePreviewsControllerGetAllResponse)
            {
                var expectedArticle = expectedArticles.Single(x => x.Title == articleViewModel.Title);
                AssertArticlePreviewViewModel(articleViewModel, expectedArticle);
            }
        }

        [Then(@"the following article previews should be returned with page numbers")]
        public void ThenTheFollowingArticlePreviewsShouldBeReturnedWithPageNumbers(Table table)
        {
            var expectedArticleViewModels = table.CreateSet<ArticlePreviewViewModel>();
            foreach (var expectedArticleViewModel in expectedArticleViewModels)
            {
                var actualArticlePreviewViewModel = articlePreviewsControllerGetAllResponse.Single(x => x.Title == expectedArticleViewModel.Title);
                actualArticlePreviewViewModel.PageNumber.Should().Be(expectedArticleViewModel.PageNumber);
            }
        }

        [Then(@"the following article should be returned")]
        public void ThenTheFollowingArticleShouldBeReturned(Table table)
        {
            var expectedArticle = table.CreateInstance<FakeArticle>();
            var actualArticleViewModel = articlesControllerGetResponse;
            AssertArticleViewModel(actualArticleViewModel, expectedArticle);
        }

        static void AssertArticlePreviewViewModel(ArticlePreviewViewModel actualArticlePreviewViewModel, FakeArticle expectedArticle)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            actualArticlePreviewViewModel.Id.Should().Be(dataContext.Articles.Single(x => x.Title == actualArticlePreviewViewModel.Title).Id);

            actualArticlePreviewViewModel.PreviewText.Should().Be(expectedArticle.PreviewText);
            actualArticlePreviewViewModel.PreviewImageFileName.Should().Be(expectedArticle.PreviewImageFileName);
            actualArticlePreviewViewModel.ThumbnailImageFileName.Should().Be(expectedArticle.ThumbnailImageFileName);
            actualArticlePreviewViewModel.CreationDate.Should().Be(expectedArticle.CreationDate);
            actualArticlePreviewViewModel.PublishDate.Should().Be(expectedArticle.PublishDate);
            actualArticlePreviewViewModel.Category.Name.Should().Be(expectedArticle.CategoryName);
            actualArticlePreviewViewModel.Category.Id.Should().Be(dataContext.ArticleCategories.Single(x => x.Name == expectedArticle.CategoryName).Id);

            var expectedTags = expectedArticle.Tags.Split(",");
            AssertTagViewModels(actualArticlePreviewViewModel.Tags, expectedTags, dataContext);
        }

        static void AssertArticleViewModel(ArticleViewModel actualArticleViewModel, FakeArticle expectedArticle)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            actualArticleViewModel.Id.Should().Be(dataContext.Articles.Single(x => x.Title == actualArticleViewModel.Title).Id);

            actualArticleViewModel.Html.Should().Be(expectedArticle.Html);
            actualArticleViewModel.ArticleImageFileName.Should().Be(expectedArticle.ArticleImageFileName);
            actualArticleViewModel.ThumbnailImageFileName.Should().Be(expectedArticle.ThumbnailImageFileName);
            actualArticleViewModel.CreationDate.Should().Be(expectedArticle.CreationDate);
            actualArticleViewModel.PublishDate.Should().Be(expectedArticle.PublishDate);
            actualArticleViewModel.Category.Name.Should().Be(expectedArticle.CategoryName);
            actualArticleViewModel.Category.Id.Should().Be(dataContext.ArticleCategories.Single(x => x.Name == expectedArticle.CategoryName).Id);

            var expectedTags = expectedArticle.Tags.Split(",");
            AssertTagViewModels(actualArticleViewModel.Tags, expectedTags, dataContext);
        }

        static void AssertTagViewModels(IEnumerable<TagViewModel> actualTags, string[] expectedTags,
            IDataContext dataContext)
        {
            actualTags.Should().HaveCount(expectedTags.Length);
            foreach (var actualTagViewModel in actualTags)
            {
                actualTagViewModel.Id.Should().Be(dataContext.Tags.Single(x => x.Name == actualTagViewModel.Name).Id);
                expectedTags.Should().Contain(actualTagViewModel.Name);
            }
        }
    }
}
