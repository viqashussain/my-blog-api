using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBlog.Domain
{
    public class ArticleTag : Entity
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
