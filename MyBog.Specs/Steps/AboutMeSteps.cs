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
    public class AboutMeSteps
    {
        AboutMeViewModel aboutMeControllerGetResponse;

        [Given(@"I have the following about me data stored")]
        public void GivenIHaveTheFollowingAboutMeDataStored(Table table)
        {
            var dataContext = ApplicationTestContext.GetInstance<IDataContext>();
            var aboutMe = table.CreateInstance<AboutMeData>();
            dataContext.AboutMeData.Add(aboutMe);
        }

        [When(@"I retrieve about me content")]
        public async Task WhenIRetrieveAboutMeContent()
        {
            var aboutMeController = ApplicationTestContext.GetInstance<AboutMeController>();
            aboutMeControllerGetResponse = await aboutMeController.Get();
        }

        [Then(@"the following about me content should be returned")]
        public void ThenTheFollowingAboutMeContentShouldBeReturned(Table table)
        {
            var expectedViewModel = table.CreateInstance<AboutMeViewModel>();
            aboutMeControllerGetResponse.HtmlContent.Should().Be(expectedViewModel.HtmlContent);
        }
    }
}
