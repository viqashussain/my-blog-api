using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Api.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public string Html { get; set; }
        public string ArticleImageFileName { get; set; }
        public DateTime PublishDate { get; set; }
        public CategoryViewModel Category { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public string ThumbnailImageFileName { get; set; }
    }
}
