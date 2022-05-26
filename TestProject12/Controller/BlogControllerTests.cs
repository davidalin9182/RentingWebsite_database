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
    public class BlogControllerTests
    {
        private BlogController _blogController;
        private IBlogRepository _blogRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContextAccessor;
        public BlogControllerTests()
        {
            //Depandancies
            _blogRepository = A.Fake<IBlogRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT
            _blogController = new BlogController(_blogRepository, _photoService, _httpContextAccessor);
        }
        [Fact]
        public void BlogController_Index_ReturnsSuccess()
        {
            //Average-What do i need to bring in?
            var Blog = A.Fake<IEnumerable<Blog>>();
            A.CallTo(() => _blogRepository.GetAll()).Returns(Blog);

            //Act
            var result = _blogController.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void BlogController_Detail_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var club = A.Fake<Blog>();
            A.CallTo(() => _blogRepository.GetByIdAsync(id)).Returns(club);
            //Act
            var result = _blogController.Detail(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

    }

}

