using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBlog.Domain
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public virtual IEnumerable<ArticleTag> ArticleTags { get; set; }
    }
}
