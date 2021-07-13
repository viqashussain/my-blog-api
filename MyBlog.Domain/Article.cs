using System;
using System.Collections.Generic;

namespace MyBlog.Domain
{
    public class Article : Entity
    {
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string PreviewText { get; set; }
        public string PreviewImageFileName { get; set; }
        public string ThumbnailImageFileName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ArticleCategory ArticleCategory { get; set; }
        public virtual List<ArticleTag> ArticleTags { get; set; }
        public virtual ArticleData ArticleData { get; set; }

        public Article()
        {
            ArticleTags = new List<ArticleTag>();
        }
    }
}
