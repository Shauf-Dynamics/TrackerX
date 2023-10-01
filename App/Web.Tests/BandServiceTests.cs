﻿using Moq;
using NUnit.Framework;
using TrackerX.Core.Band;
using TrackerX.Core.Band.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Entities.Repositories;

namespace TrackerX.Tests.Unit
{
    [TestFixture]
    public class BandServiceTests
    {
        private IBandService _sut;
        private Mock<IBandRepository> _bandRepositoryMock;

        [SetUp]
        public void Init()
        {
            _bandRepositoryMock = new Mock<IBandRepository>();
            _bandRepositoryMock.Setup(x => x.SaveChanges());
        }

        [Test]
        public async Task Should_CreateBand_AssingPassedValues()
        {
            _bandRepositoryMock.Setup(x => x.Create(It.IsAny<Band>()));            
            _sut = new BandService(_bandRepositoryMock.Object);

            var createBandModel = new CreateBandModel() { BandName = "cool name" };
            await _sut.CreateBand(createBandModel);

            _bandRepositoryMock.Verify(x => x.Create(It.Is<Band>(x => createBandModel.BandName == x.BandName)), Times.Once);
            _bandRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task Should_RenameBand_StoreNewName()
        {
            int id = 1;
            
            _bandRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(new Band()));
            _sut = new BandService(_bandRepositoryMock.Object);
            
            await _sut.RenameBand(id, "new cool name");

            _bandRepositoryMock.Verify(x => x.GetById(It.Is<int>(x => x == id)), Times.Once);
            _bandRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
