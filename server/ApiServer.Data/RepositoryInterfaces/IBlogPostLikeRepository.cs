namespace ApiServer.Data.RepositoryInterfaces
{
    public interface IBlogPostLikeRepository :IRepository<BlogPostLike>
    {
        Task<int> GetCountByBlogPostId(Guid id);
    }
}
