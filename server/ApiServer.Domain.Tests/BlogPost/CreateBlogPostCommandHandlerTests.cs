using ApiServer.Data.EF;
using ApiServer.Data.EF.EntityRepositories;
using ApiServer.Data.RepositoryInterfaces;
using ApiServer.Domain.Entities.BlogPost;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Moq;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Domain.Tests.BlogPost
{
    //public class CreateBlogPostCommandHandlerTests
    //{
    //    private readonly ILogger<CreateBlogPostCommandHandler> _logger;
    //    private readonly Mock<IConfiguration> _mockConfiguration = new Mock<IConfiguration>();

    //    public CreateBlogPostCommandHandlerTests()
    //    {
    //        _logger = Mock.Of<ILogger<CreateBlogPostCommandHandler>>();
    //    }

    //    [Fact]
    //    public async Task Create_BlogPost_ComandHandler_ReturnsAGuid()
    //    {
    //        //Arrange
    //        //var context = Mock.Of<IBlogPostRepository>();

    //        //var repository = new Mock<IBlogPostRepository>();
    //        var context = Mock<MainDbContext>;
    //        var repository = new BlogPostRepository()
            
    //        var userId = Guid.NewGuid();
    //        var blogPostId = Guid.NewGuid();
    //        var blogPostModel = new Model.BlogPost
    //        {
    //            Author = new Model.User { Name = "Greg", Id = userId, Email = "test@.com" },
    //            AuthorId = userId,
    //            Id = blogPostId,
    //            Title = "Title",
    //            PostContent = "Post contetnt ahhashhsd",
    //            ImageLocation = ",,"
    //        };

    //        repository.Setup(x => x.CreateAsync(blogPostModel, default, true)).Returns(Task.FromResult(blogPostModel));

    //        var sut = new CreateBlogPostCommandHandler(_logger, repository.Object);
     

    //        //Act
    //        var result = await sut.Handle(new CreateBlogPostCommand(blogPostModel), default);

    //        //Assert
    //        Assert.True(result == blogPostId);
    //    }
   // }
}
