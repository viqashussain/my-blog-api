using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain;
using MyBlog.EntityFramework;

namespace MyBlog.CommandQuery.Queries
{
    public class GetEntityByIdQuery
    {
        readonly IDataContext dataContext;

        public GetEntityByIdQuery(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<TEntity> Execute<TEntity>(int id) where TEntity : Entity
        {
            return await dataContext.Set<TEntity>().SingleAsync(x => x.Id == id);
        }
    }
}
