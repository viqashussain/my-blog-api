using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain;
using MyBlog.EntityFramework;

namespace MyBlog.CommandQuery.Queries
{
    public class GetArticlesByTagQuery
    {
        readonly IDataContext dataContext;

        public GetArticlesByTagQuery(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Article>> Execute(int id)
        {
            return await dataContext.ArticleTags.Where(x => x.ArticleTags.Any(at => at.TagId == id)).ToListAsync();
        }
    }
}
