using AutoFixture;
using AutoMapper;
using FluentAssertions;
using InnoEvents.Controllers;
using InnoEvents.Infrastructure;
using InnoEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InnoEvents.Tests
{
    public class EventsControllerTests
    {       


        [Theory]
        [InlineData(0, 5)]
        public async Task GetAll_ReturnsAllEvents(int pageNumber, int pageSize)
        {
            Fixture fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new InnoProfile()));
            var mapper = new Mapper(configuration);

            var mockMapper = new Mock<IMapper>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var events = fixture.CreateMany<Event>();
            var dtoEvents = mapper.Map<IEnumerable<DTOs.Event>>(events);

            var pagingParams = fixture.Create<PagingParams>();

            pagingParams.PageNumber = pageNumber;
            pagingParams.PageSize = pageSize;

            mockMapper.Setup(dr => dr.Map<IEnumerable<DTOs.Event>>(It.IsAny<IEnumerable<Event>>()))
                                  .Returns(dtoEvents);
            mockUnitOfWork.Setup(dr => dr.EventRepository.GetAllAsync(pageNumber, pageSize))
                                  .ReturnsAsync(events);

            var eventsController = new EventsController(mockMapper.Object, mockUnitOfWork.Object);
            var result = await eventsController.GetAll(pagingParams) as OkObjectResult; 

            result.Value.Should().BeEquivalentTo(dtoEvents);
        }
    }
}