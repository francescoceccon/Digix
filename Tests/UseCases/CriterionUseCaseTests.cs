using Application.UseCases;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Repository.Interfaces;
using Moq;

namespace Tests.UseCases;
public class CriterionUseCaseTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IBaseRepository<Family>> _repositoryMock;
    private readonly CriterionUseCase _useCase;

    public CriterionUseCaseTests()
    {
        _mapperMock = new Mock<IMapper>();
        _repositoryMock = new Mock<IBaseRepository<Family>>();
        _useCase = new CriterionUseCase(_mapperMock.Object, _repositoryMock.Object);
    }

    [Fact(DisplayName = "Should insert family into Repository")]
    public async Task ShouldInsertFamilyIntoRepository()
    {
        // Arrange
        var family = new Family();

        // Act
        await _useCase.InsertFamilyAsync(family);

        // Assert
        _repositoryMock.Verify(repo => repo.Insert(family), Times.Once);
    }

    [Fact(DisplayName = "Should apply criteria by Strategy")]
    public async Task ShouldApplyCriteriaToEachFamilyByStrategyAndSortByIncome()
    {
        // Arrange
        var families = new List<Family>
        {
            new Family
            {
                Holder = new Person()
                {
                    Name = "Luiz",
                    Age = 51,
                    Salary = 6000

                } 
            },
            new Family
            {
                Holder = new Person()
                {
                    Name = "Lara",
                    Age = 52,
                    Salary = 5000

                }
            },
            new Family
            {
                Holder = new Person()
                {
                    Name = "Jose",
                    Age = 53,
                    Salary = 4000

                }
            },
        };

        _repositoryMock.Setup(repo => repo.SelectList()).ReturnsAsync(families);

        // Act
        var result = await _useCase.ApplyCriterionStrategyAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);

        var sortedFamilies = families.OrderBy(f => f.Income).ToList();

        for (int i = 0; i < result.Count(); i++)
        {
            result.ElementAt(i).Income.Should().Be(sortedFamilies[i].Income);
        }
    }

    [Fact(DisplayName = "Should apply criteria by Chain Of Responsability")]
    public async Task ShouldApplyCriteriaToEachFamilyByChainOfResponsabilityAndSortByIncome()
    {
        // Arrange
        var families = new List<Family>
        {
            new Family
            {
                Holder = new Person()
                {
                    Name = "Luiz",
                    Age = 51,
                    Salary = 6000

                }
            },
            new Family
            {
                Holder = new Person()
                {
                    Name = "Lara",
                    Age = 52,
                    Salary = 5000

                }
            },
            new Family
            {
                Holder = new Person()
                {
                    Name = "Jose",
                    Age = 53,
                    Salary = 4000

                }
            },
        };

        _repositoryMock.Setup(repo => repo.SelectList()).ReturnsAsync(families);

        // Act
        var result = await _useCase.ApplyCriterionChainAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);

        var sortedFamilies = families.OrderBy(f => f.Income).ToList();

        for (int i = 0; i < result.Count(); i++)
        {
            result.ElementAt(i).Income.Should().Be(sortedFamilies[i].Income);
        }
    }
}
