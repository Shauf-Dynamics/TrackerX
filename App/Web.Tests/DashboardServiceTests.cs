using Domain.Entity;
using Domain.Repository;
using Moq;
using NUnit.Framework;

using Web.Application.Endpoints.Dashboard.Service;

namespace Web.Tests
{
    [TestFixture]
    public class DashboardServiceTests
    {
        private IDashboardService _sut;
        private Mock<IRecordRepository> _recordRepositoryMock;

        [SetUp]
        public void Init()
        {
            _recordRepositoryMock = new Mock<IRecordRepository>();
            _sut = new DashboardService(_recordRepositoryMock.Object);
        }

        [Test]
        public async Task GetDashboardResult_ShouldReturn_EmptyRecordSet_IfNoRecords()
        {
            _recordRepositoryMock
                .Setup(x => x.GetLastRecords(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(Enumerable.Empty<Record>());

            var result = await _sut.GetDashboardResult(default);

            CollectionAssert.IsEmpty(result.LastRecords);
        }

        [Test]
        public async Task GetDashboardResult_ShouldReturn_NullLastTrackedDateTime_IfNoRecords()
        {
            _recordRepositoryMock
                    .Setup(x => x.GetLastRecords(It.IsAny<int>(), It.IsAny<int>()))
                    .ReturnsAsync(Enumerable.Empty<Record>());

            var result = await _sut.GetDashboardResult(default);

            Assert.IsNull(result.LastTrackedDateTime);
        }

        [Test]
        public async Task GetDashboardResult_ShouldReturn_NulllLastWeekActiveDays_IfNoRecords()
        {
            _recordRepositoryMock
                    .Setup(x => x.GetLastRecords(It.IsAny<int>(), It.IsAny<int>()))
                    .ReturnsAsync(Enumerable.Empty<Record>());

            var result = await _sut.GetDashboardResult(default);

            Assert.IsNull(result.LastWeekActiveDays);
        }
    }
}
