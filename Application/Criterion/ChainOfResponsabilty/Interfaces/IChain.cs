using Domain.Entities;

namespace Application.Criterion.ChainOfResponsabilty.Interfaces
{
    public interface IChain
    {
        Family ApplyCriterionChain(Family family);
        public IChain Next { get; set; }
    }
}
