using Domain.DTO;
using Domain.Entities;

namespace Application.Criterion.Strategy.Interfaces
{
    public interface IStrategy
    {
        Family ApplyCriterion(Family family);
    }
}
