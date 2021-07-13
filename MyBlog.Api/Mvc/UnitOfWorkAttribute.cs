using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.EntityFramework;

namespace MyBlog.Api.Mvc
{
    public sealed class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            await next();
            var dataContext = ApplicationContext.Container.GetInstance(typeof(IDataContext)) as IDataContext;
            await dataContext.SaveChangesAsync();
        }
    }
}
