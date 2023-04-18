namespace ApiServer.Model
{
    public class BlogPost : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageLocation { get; set; }
        public Guid AuthorId { get; set; } = Guid.Empty;
        public virtual User Author { get; set; }
        public string PostContent { get; set; }
        //Tags?
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public int Version { get; set; } = 1;

        public virtual ICollection<BlogPostComment> BlogPostComments { get; set; }
        public virtual ICollection<BlogPostLike> BlogPostLikes { get; set;}
    }
}
