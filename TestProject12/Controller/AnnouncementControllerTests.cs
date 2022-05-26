using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_DATABASE.Controllers;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Models;
using Xunit;
//a
namespace Test1.Controller
{
    public class AnnouncementControllerTests
    {
        private AnnouncementController _announcementController;
        private IAnnouncementRepository _announcementRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContextAccessor;
        public AnnouncementControllerTests()
        {
            //Depandancies
            _announcementRepository = A.Fake<IAnnouncementRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT
            _announcementController = new AnnouncementController(_announcementRepository, _photoService, _httpContextAccessor);
        }
        [Fact]
        public void AnnouncementController_Index_ReturnsSuccess()
        {
            //Average-What do i need to bring in?
            var Announcement = A.Fake<IEnumerable<Announcement>>();
            A.CallTo(() => _announcementRepository.GetAll()).Returns(Announcement);

            //Act
            var result = _announcementController.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AnnouncementController_Detail_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var club = A.Fake<Announcement>();
            A.CallTo(() => _announcementRepository.GetByIdAsync(id)).Returns(club);
            //Act
            var result = _announcementController.Detail(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

    }

}

