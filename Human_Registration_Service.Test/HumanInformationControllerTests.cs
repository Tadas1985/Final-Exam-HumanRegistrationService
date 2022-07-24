using AutoFixture.Xunit2;
using Human_Registration_Service.Controllers;
using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
using Moq;
using System;
using Xunit;

namespace Human_Registration_Service.Test
{
    public class HumanInformationControllerTests
    {
        //[Theory, AutoData]
        //public void Test1(HumanInformation humanInformation)
        //{
        //    var repositoryMock = new Mock<IHumanInformationRepository>();
        //    //var imageMock = new Mock<IImageRepository>();
        //    //var locationRepositoryMock = new Mock<ILocationRepository>();
        //    //var userRepoisitoryMock = new Mock<IUserInformationRepository>();
        //    var sut = new HumanInformationController(repositoryMock.Object);
        //    repositoryMock.Setup(x=>x.GetHumanInformation(It.IsAny<Guid>())).Returns(humanInformation);
        //    var testResponse = sut.GetHumanInformation(It.IsAny<Guid>());
        //    Assert.Equal(testResponse, humanInformation);
        //}
    }
}
