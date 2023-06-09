﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Model
{
    public class BlogPostLike : IEntity
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
