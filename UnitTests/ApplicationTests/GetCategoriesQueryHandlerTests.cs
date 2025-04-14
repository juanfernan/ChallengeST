using Application.Categories.Queries;
using Application.Common.Mappings;
using Application.Exeptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using FluentAssertions;
using Moq;

namespace UnitTests.ApplicationTests;

public class GetCategoriesQueryHandlerTests
{
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandlerTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldReturnCategoryDtos_WhenDataExists()
    {
        // Arrange
        var categories = new List<Category>
        {
            new() {
                CategoryName = "Iluminacion",
                Items =
                [
                    new Item { Element = "Lámpara Led de 5w", Value = 5 },
                    new Item { Element = "Lámpara Led de 10w", Value = 10 }
                ]
            }
        };

        var categoryServiceMock = new Mock<IGet<Category>>();
        categoryServiceMock
            .Setup(x => x.GetAll())
            .ReturnsAsync(categories);

        var handler = new GetCategoriesQueryHandler(categoryServiceMock.Object, _mapper);

        // Act
        var result = await handler.Handle(new GetCategoriesQuery(), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.First().Category.Should().Be("Iluminacion");
        result.First().Items.Should().HaveCount(2);
        result.First().Items.First().Element.Should().Be("Lámpara Led de 5w");
    }

    [Fact]
    public async Task Handle_ShouldThrow_WhenNoDataExists()
    {
        // Arrange
        var categoryServiceMock = new Mock<IGet<Category>>();
        categoryServiceMock
            .Setup(x => x.GetAll())
            .ReturnsAsync([]);

        var handler = new GetCategoriesQueryHandler(categoryServiceMock.Object, _mapper);

        // Act
        Func<Task> act = async () => await handler.Handle(new GetCategoriesQuery(), CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<GetCategoriesException>();
    }
}
