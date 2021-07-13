using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain;
using MyBlog.EntityFramework;

namespace MyBlog.CommandQuery.Queries
{
    public class GetAboutMeDataQuery
    {
        readonly IDataContext dataContext;

        public GetAboutMeDataQuery(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<AboutMeData> Execute()
        {
            return await dataContext.AboutMeData.FirstAsync();
        }
    }
}
