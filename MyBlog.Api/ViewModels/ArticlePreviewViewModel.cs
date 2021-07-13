using System;
using System.Collections.Generic;

namespace MyBlog.Api.ViewModels
{
    public class ArticlePreviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string PreviewText { get; set; }
        public DateTime CreationDate { get; set; }
        public string PreviewImageFileName { get; set; }
        public DateTime PublishDate { get; set; }
        public CategoryViewModel Category { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public string ThumbnailImageFileName { get; set; }
        public int PageNumber { get; set; }
    }
}
