// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MyBog.Specs.Articles
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RetrievingArticlesFeature : Xunit.IClassFixture<RetrievingArticlesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "RetrievingArticles.feature"
#line hidden
        
        public RetrievingArticlesFeature(RetrievingArticlesFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RetrievingArticles", "\tAs a public user\t\r\n\tI can retrieve a list of all the articles", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table5.AddRow(new string[] {
                        "Clean Code"});
            table5.AddRow(new string[] {
                        "Frameworks"});
#line 6
 testRunner.Given("I have the following article categories stored", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table6.AddRow(new string[] {
                        "JavaScript"});
            table6.AddRow(new string[] {
                        "CSharp"});
            table6.AddRow(new string[] {
                        "React"});
            table6.AddRow(new string[] {
                        "Angular"});
#line 10
 testRunner.And("I have the following article tags stored", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "CreationDate",
                        "Html",
                        "PublishDate",
                        "CategoryName",
                        "ArticleImageFileName",
                        "PreviewImageFileName",
                        "PreviewText",
                        "ThumbnailImageFileName"});
            table7.AddRow(new string[] {
                        "Why Angular is better than React",
                        "2018-01-01",
                        "<b>Google!</b>",
                        "2019-01-01",
                        "Frameworks",
                        "xx1",
                        "x1",
                        "Angular is...",
                        "y1"});
            table7.AddRow(new string[] {
                        "Everything about Uncle Bob",
                        "2019-02-02",
                        "<u>Let\'s start with the stars!</u>",
                        "2019-01-02",
                        "Clean Code",
                        "xx2",
                        "x2",
                        "Uncle bob...",
                        "y2"});
            table7.AddRow(new string[] {
                        "Lifecyle hooks",
                        "2018-01-01",
                        "<b>ngOnInit</b>",
                        "2019-01-01",
                        "Frameworks",
                        "xx3",
                        "x3",
                        "Life...",
                        "y3"});
#line 16
 testRunner.Given("I have the following articles stored", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table8.AddRow(new string[] {
                        "Angular"});
#line 21
 testRunner.And("the article \'Lifecyle hooks\' have the following tags", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table9.AddRow(new string[] {
                        "Angular"});
            table9.AddRow(new string[] {
                        "React"});
#line 24
 testRunner.And("the article \'Why Angular is better than React\' have the following tags", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table10.AddRow(new string[] {
                        "CSharp"});
            table10.AddRow(new string[] {
                        "JavaScript"});
#line 28
 testRunner.And("the article \'Everything about Uncle Bob\' have the following tags", ((string)(null)), table10, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="I can retrieve all preview articles")]
        [Xunit.TraitAttribute("FeatureTitle", "RetrievingArticles")]
        [Xunit.TraitAttribute("Description", "I can retrieve all preview articles")]
        public virtual void ICanRetrieveAllPreviewArticles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can retrieve all preview articles", null, ((string[])(null)));
#line 33
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 34
 testRunner.When("I retrieve a list of all the article previews", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "CreationDate",
                        "PreviewText",
                        "PublishDate",
                        "CategoryName",
                        "Tags",
                        "PreviewImageFileName",
                        "ThumbnailImageFileName"});
            table11.AddRow(new string[] {
                        "Why Angular is better than React",
                        "2018-01-01",
                        "Angular is...",
                        "2019-01-01",
                        "Frameworks",
                        "Angular,React",
                        "x1",
                        "y1"});
            table11.AddRow(new string[] {
                        "Everything about Uncle Bob",
                        "2019-02-02",
                        "Uncle bob...",
                        "2019-01-02",
                        "Clean Code",
                        "CSharp,JavaScript",
                        "x2",
                        "y2"});
            table11.AddRow(new string[] {
                        "Lifecyle hooks",
                        "2018-01-01",
                        "Life...",
                        "2019-01-01",
                        "Frameworks",
                        "Angular",
                        "x3",
                        "y3"});
#line 35
 testRunner.Then("the following article previews should be returned", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="I can retrieve an article")]
        [Xunit.TraitAttribute("FeatureTitle", "RetrievingArticles")]
        [Xunit.TraitAttribute("Description", "I can retrieve an article")]
        public virtual void ICanRetrieveAnArticle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can retrieve an article", null, ((string[])(null)));
#line 41
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 42
 testRunner.When("I retrieve the article with title \'Why Angular is better than React\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "CreationDate",
                        "Html",
                        "PublishDate",
                        "CategoryName",
                        "Tags",
                        "ArticleImageFileName",
                        "ThumbnailImageFileName"});
            table12.AddRow(new string[] {
                        "Why Angular is better than React",
                        "2018-01-01",
                        "<b>Google!</b>",
                        "2019-01-01",
                        "Frameworks",
                        "Angular,React",
                        "xx1",
                        "y1"});
#line 43
 testRunner.Then("the following article should be returned", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="I can retrieve articles by hashtag")]
        [Xunit.TraitAttribute("FeatureTitle", "RetrievingArticles")]
        [Xunit.TraitAttribute("Description", "I can retrieve articles by hashtag")]
        public virtual void ICanRetrieveArticlesByHashtag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can retrieve articles by hashtag", null, ((string[])(null)));
#line 47
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 48
 testRunner.When("I retrieve the articles with hashtag \'Angular\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "CreationDate",
                        "PreviewText",
                        "PublishDate",
                        "CategoryName",
                        "Tags",
                        "PreviewImageFileName",
                        "ThumbnailImageFileName"});
            table13.AddRow(new string[] {
                        "Why Angular is better than React",
                        "2018-01-01",
                        "Angular is...",
                        "2019-01-01",
                        "Frameworks",
                        "Angular,React",
                        "x1",
                        "y1"});
            table13.AddRow(new string[] {
                        "Lifecyle hooks",
                        "2018-01-01",
                        "Life...",
                        "2019-01-01",
                        "Frameworks",
                        "Angular",
                        "x3",
                        "y3"});
#line 49
 testRunner.Then("the following article previews should be returned", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="I can retrieve articles by category")]
        [Xunit.TraitAttribute("FeatureTitle", "RetrievingArticles")]
        [Xunit.TraitAttribute("Description", "I can retrieve articles by category")]
        public virtual void ICanRetrieveArticlesByCategory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can retrieve articles by category", null, ((string[])(null)));
#line 54
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 55
 testRunner.When("I retrieve the articles by category \'Frameworks\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "CreationDate",
                        "PreviewText",
                        "PublishDate",
                        "CategoryName",
                        "Tags",
                        "PreviewImageFileName",
                        "ThumbnailImageFileName"});
            table14.AddRow(new string[] {
                        "Why Angular is better than React",
                        "2018-01-01",
                        "Angular is...",
                        "2019-01-01",
                        "Frameworks",
                        "Angular,React",
                        "x1",
                        "y1"});
            table14.AddRow(new string[] {
                        "Lifecyle hooks",
                        "2018-01-01",
                        "Life...",
                        "2019-01-01",
                        "Frameworks",
                        "Angular",
                        "x3",
                        "y3"});
#line 56
 testRunner.Then("the following article previews should be returned", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Articles previews are retrieved with pages numbers ordered by publish date")]
        [Xunit.TraitAttribute("FeatureTitle", "RetrievingArticles")]
        [Xunit.TraitAttribute("Description", "Articles previews are retrieved with pages numbers ordered by publish date")]
        public virtual void ArticlesPreviewsAreRetrievedWithPagesNumbersOrderedByPublishDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Articles previews are retrieved with pages numbers ordered by publish date", null, ((string[])(null)));
#line 61
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "PublishDate",
                        "CategoryName"});
            table15.AddRow(new string[] {
                        "Article page 2_1",
                        "2018-03-03",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 2_2",
                        "2018-03-02",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 2_3",
                        "2018-03-01",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 1_1",
                        "2018-04-03",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 1_2",
                        "2018-04-02",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 1_3",
                        "2018-04-01",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 3_1",
                        "2018-02-03",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 3_2",
                        "2018-02-02",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 3_3",
                        "2018-02-01",
                        "Frameworks"});
            table15.AddRow(new string[] {
                        "Article page 4_1",
                        "2018-02-01",
                        "Frameworks"});
#line 62
 testRunner.Given("I have the following articles stored", ((string)(null)), table15, "Given ");
#line 74
 testRunner.When("I retrieve a list of all the article previews", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "PageNumber"});
            table16.AddRow(new string[] {
                        "Article page 2_1",
                        "2"});
            table16.AddRow(new string[] {
                        "Article page 2_2",
                        "2"});
            table16.AddRow(new string[] {
                        "Article page 2_3",
                        "2"});
            table16.AddRow(new string[] {
                        "Article page 1_1",
                        "1"});
            table16.AddRow(new string[] {
                        "Article page 1_2",
                        "1"});
            table16.AddRow(new string[] {
                        "Article page 1_3",
                        "1"});
            table16.AddRow(new string[] {
                        "Article page 3_1",
                        "3"});
            table16.AddRow(new string[] {
                        "Article page 3_2",
                        "3"});
            table16.AddRow(new string[] {
                        "Article page 3_3",
                        "3"});
            table16.AddRow(new string[] {
                        "Article page 4_1",
                        "4"});
#line 75
 testRunner.Then("the following article previews should be returned with page numbers", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RetrievingArticlesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RetrievingArticlesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
