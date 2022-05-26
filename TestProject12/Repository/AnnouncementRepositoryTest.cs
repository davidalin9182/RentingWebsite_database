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
    public class AnnouncementRepositoryTest
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Announcement.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Announcement.Add(
                      new Announcement()
                      {
                          AnnouncementName = "Apartment in Craiova",
                          Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                          Description = "This is the description of the first cinema", 
                          Location = "Craiova",
                          Surface = 24000,
                          PropertyType = "Apartment",
                          Price = 2000,
                          Phone = 0735674324,
                      });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void AnnouncementRepository_Add_ReturnsBool()
        {
            //Arrange
            var Announcement = new Announcement()
            {
                AnnouncementName = "Apartment in Craiova",
                Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                Description = "This is the description of the first cinema",
                Location = "Craiova",
                Surface = 24000,
                PropertyType = "Apartment",
                Price = 2000,
                Phone = 0735674324,
            };
            var dbContext = await GetDbContext();
            var AnnouncementRepository = new AnnouncementRepository(dbContext);

            //Act
            var result = AnnouncementRepository.Add(Announcement);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void AnnouncementRepository_GetByIdAsync_ReturnsAnnouncement()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var AnnouncementRepository = new AnnouncementRepository(dbContext);

            //Act
            var result = AnnouncementRepository.GetByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Announcement>>();
        }

        [Fact]
        public async void AnnouncementRepository_GetAll_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var AnnouncementRepository = new AnnouncementRepository(dbContext);

            //Act
            var result = await AnnouncementRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Announcement>>();
        }

        [Fact]
        public async void AnnouncementRepository_SuccessfulDelete_ReturnsTrue()
        {
            //Arrange
            var Announcement = new Announcement()
            {
                AnnouncementName = "Apartment in Craiova",
                Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                Description = "This is the description of the first cinema",
                Location = "Craiova",
                Surface = 24000,
                PropertyType = "Apartment",
                Price = 2000,
                Phone = 0735674324,
            };
            var dbContext = await GetDbContext();
            var AnnouncementRepository = new AnnouncementRepository(dbContext);

            //Act
            AnnouncementRepository.Add(Announcement);
            var result = AnnouncementRepository.Delete(Announcement);
            var count = await AnnouncementRepository.GetCountAsync();

            //Assert
            result.Should().BeTrue();
            count.Should().Be(0);
        }


        [Fact]
        public async void AnnouncementRepositoryGetAll_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var AnnouncementRepository = new AnnouncementRepository(dbContext);

            //Act
            var result = await AnnouncementRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Announcement>>();
        }

        [Fact]
        public async void AnnouncementRepository_GetCountAsync_ReturnsInt()
        {
            //Arrange
            var Announcement = new Announcement()
            {
                AnnouncementName = "Apartment in Craiova",
                Image = "file:///C:/Users/Z/Desktop/ultimaversiune/RentingWebsite_database-branch2/WAD_DATABASE/wwwroot/Images/home-interior-background-for-video-conferencing-vector-34878946.jpg",
                Description = "This is the description of the first cinema",
                Location = "Craiova",
                Surface = 24000,
                PropertyType = "Apartment",
                Price = 2000,
                Phone = 0735674324,
            
            };
            var dbContext = await GetDbContext();
            var AnnouncementRepository = new AnnouncementRepository(dbContext);

            //Act
            AnnouncementRepository.Add(Announcement);
            var result = await AnnouncementRepository.GetCountAsync();

            //Assert
            result.Should().Be(1);
        }

        
    }
}

