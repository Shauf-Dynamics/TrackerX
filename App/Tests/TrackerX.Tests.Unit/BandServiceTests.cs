using Moq;
using NUnit.Framework;
using TrackerX.Services.Bands;
using TrackerX.Services.Bands.Models;
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
            _bandRepositoryMock.Setup(x => x.SaveChangesAsync());
        }

        [Test]
        public async Task Should_CreateBand_AssingPassedValues()
        {
            _bandRepositoryMock.Setup(x => x.Create(It.IsAny<Band>()));            
            _sut = new BandService(_bandRepositoryMock.Object, null);

            var createBandModel = new CreateBandModel() { BandName = "cool name" };
            await _sut.CreateBand(createBandModel);

            _bandRepositoryMock.Verify(x => x.Create(
                It.Is<Band>(x => createBandModel.BandName == x.BandName)),
                Times.Once);
            _bandRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task Should_RenameBand_StoreNewName()
        {
            int id = 1;
            
            _bandRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Band() { BandName = "default name" }));
            _sut = new BandService(_bandRepositoryMock.Object, null);
            
            await _sut.RenameBand(id, "new cool name");

            _bandRepositoryMock.Verify(x => x.GetByIdAsync(It.Is<int>(x => x == id)), Times.Once);
            _bandRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task Should_GetBandsByCriterias_Return_ExactNumberOfBands()
        {
            IEnumerable<Band> bands = new List<Band>()
            {
                new Band() { BandName = "Megadeth" },
                new Band() { BandName = "Metallica" },
                new Band() { BandName = "Pantera" }
            };

            _bandRepositoryMock.Setup(x => x.GetBySearchingCriteriasAsync(
                It.IsAny<int>(),
                It.IsAny<string>()))
                .Returns(Task.FromResult(bands));
            _sut = new BandService(_bandRepositoryMock.Object, null);

            var result = await _sut.GetBandsByCriterias(new BandSearchParams(99, string.Empty));

            Assert.That(result.Count(), Is.EqualTo(bands.Count()));
            _bandRepositoryMock.Verify(x => x.GetBySearchingCriteriasAsync(
                It.IsAny<int>(),
                It.IsAny<string>()), 
                Times.Once);            
        }    
    }
}
