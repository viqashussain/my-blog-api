using System;
using System.Collections.Generic;
using System.Text;

namespace MyBog.Specs.Fakes
{
    public class FakeArticle
    {
        public string Title { get; set; }
        public string Html { get; set; }
        public string ArticleImageFileName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishDate { get; set; }
        public string CategoryName { get; set; }
        public string Tags { get; set; }
        public string PreviewText { get; set; }
        public string PreviewImageFileName { get; set; }
        public string ThumbnailImageFileName { get; set; }
    }
}
