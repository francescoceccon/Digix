using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Criterion.ChainOfResponsabilty
{
    public class FirstCriterionChain : IChain
    {
        public IChain Next { get; set; } = new SecondCriteriaChain();

        public Family ApplyCriterionChain(Family family)
        {
            if (family is { Income: <= 900 })
            {
                family.Score += 5;
                return Next.ApplyCriterionChain(family);
            }
            return Next.ApplyCriterionChain(family);
        }
    }
}
