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
    public class TagSteps
    {
        TagViewModel tagControllerGetResponse;

        [When(@"I retrieve the tag '(.*)'")]
        public async Task WhenIRetrieveTheTag(string tagName)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var articleId = dataContext.Tags.Single(x => x.Name == tagName).Id;
            var tagController = ApplicationTestContext.GetInstance<TagController>();
            tagControllerGetResponse = await tagController.Get(articleId);
        }

        [Then(@"the following tag should be returned")]
        public void ThenTheFollowingTagShouldBeReturned(Table table)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var expectedTag = table.CreateInstance<TagViewModel>();
            var actualTagViewModel = tagControllerGetResponse;
            actualTagViewModel.Id.Should().Be(dataContext.Tags.Single(x => x.Name == actualTagViewModel.Name).Id);
            expectedTag.Name.Should().Be(actualTagViewModel.Name);
        }
    }
}
