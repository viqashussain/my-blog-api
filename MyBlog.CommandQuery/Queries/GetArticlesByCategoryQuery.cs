using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain;
using MyBlog.EntityFramework;

namespace MyBlog.CommandQuery.Queries
{
    public class GetArticlesByCategoryQuery
    {
        readonly IDataContext dataContext;

        public GetArticlesByCategoryQuery(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Article>> Execute(int id)
        {
            return await dataContext.Articles.Where(x => x.ArticleCategory.Id == id).ToListAsync();
        }
    }
}
