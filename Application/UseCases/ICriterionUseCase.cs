using Domain.DTO;
using Domain.Entities;

namespace Application.UseCases
{
    public interface ICriterionUseCase
    {
        Task<IEnumerable<FamilyDTO>> ApplyCriterionStrategyAsync();
        Task<IEnumerable<FamilyDTO>> ApplyCriterionChainAsync();
        Task InsertFamilyAsync(Family family);
    }
}