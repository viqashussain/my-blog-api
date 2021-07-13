using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace MyBog.Specs
{
    public static class ApplicationTestContext
    {
        static Container containerInstance;

        public static Container Container => containerInstance ?? (containerInstance = new Container());

        static Scope scope;

        public static void BeginScope()
        {
            scope = AsyncScopedLifestyle.BeginScope(containerInstance);
        }

        public static T GetInstance<T>() where T : class
        {
            return scope.GetInstance<T>();
        }
    }
}
