using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.Repository;
using Xunit;
//a
namespace Test1.Repository
{
    public class BlogRepositoryTest
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Blog.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Blog.Add(
                      new Blog()
                      {
                          BlogName = "Apartment in Craiova",
                          Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                          Description = "This is the description of the first cinema",

                      });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void BlogRepository_Add_ReturnsBool()
        {
            //Arrange
            var Blog = new Blog()
            {
                BlogName = "Apartment in Craiova",
                Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                Description = "This is the description of the first cinema",

            };
            var dbContext = await GetDbContext();
            var BlogRepository = new BlogRepository(dbContext);

            //Act
            var result = BlogRepository.Add(Blog);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void BlogRepository_GetByIdAsync_ReturnsBlog()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var BlogRepository = new BlogRepository(dbContext);

            //Act
            var result = BlogRepository.GetByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Blog>>();
        }

        [Fact]
        public async void BlogRepository_GetAll_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var BlogRepository = new BlogRepository(dbContext);

            //Act
            var result = await BlogRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Blog>>();
        }

        [Fact]
        public async void BlogRepository_SuccessfulDelete_ReturnsTrue()
        {
            //Arrange
            var Blog = new Blog()
            {
                BlogName = "Apartment in Craiova",
                Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                Description = "This is the description of the first cinema",

            };
            var dbContext = await GetDbContext();
            var BlogRepository = new BlogRepository(dbContext);

            //Act
            BlogRepository.Add(Blog);
            var result = BlogRepository.Delete(Blog);
            var count = await BlogRepository.GetCountAsync();

            //Assert
            result.Should().BeTrue();
            count.Should().Be(0);
        }

        [Fact]
        public async void BlogRepository_GetCountAsync_ReturnsInt()
        {
            //Arrange
            var Blog = new Blog()
            {
                BlogName = "Apartment in Craiova",
                Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                Description = "This is the description of the first cinema",


            };
            var dbContext = await GetDbContext();
            var BlogRepository = new BlogRepository(dbContext);

            //Act
            BlogRepository.Add(Blog);
            var result = await BlogRepository.GetCountAsync();

            //Assert
            result.Should().Be(1);
        }


    }
}

