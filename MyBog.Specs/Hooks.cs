using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyBlog.CommandQuery.Queries;
using MyBlog.EntityFramework;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using TechTalk.SpecFlow;

namespace MyBog.Specs
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ApplicationTestContext.Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            ApplicationTestContext.Container.Options.AllowOverridingRegistrations = true;

            ApplicationTestContext.Container.Register<IDataContext>(() => {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                return new DataContext(options);
            }, Lifestyle.Scoped);

            RegisterCommandQueryNameSpace();

            ApplicationTestContext.Container.Register<TestContext>(Lifestyle.Scoped);
        }

        static void RegisterCommandQueryNameSpace()
        {
            var registrations =
                from type in typeof(GetEntityByIdQuery).Assembly.GetExportedTypes()
                where type.Namespace.StartsWith("MyBlog.CommandQuery")
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().SingleOrDefault() ?? type, Implementation = type };

            foreach (var reg in registrations)
            {
                ApplicationTestContext.Container.Register(reg.Service, reg.Implementation);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            ApplicationTestContext.BeginScope();
        }

        [AfterStep]
        public static async void AfterStep()
        {
            await ApplicationTestContext.GetInstance<IDataContext>().SaveChangesAsync();
        }
    }
}
