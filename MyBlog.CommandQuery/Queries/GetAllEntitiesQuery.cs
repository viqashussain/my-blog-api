using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain;
using MyBlog.EntityFramework;

namespace MyBlog.CommandQuery.Queries
{
    public class GetAllEntitiesQuery
    {
        readonly IDataContext dataContext;

        public GetAllEntitiesQuery(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<TEntity>> Execute<TEntity>() where TEntity : Entity
        {
            return await dataContext.Set<TEntity>().ToListAsync();
        }
    }
}
