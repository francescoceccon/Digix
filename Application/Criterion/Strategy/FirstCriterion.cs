using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.DTO;
using Domain.Entities;

namespace Application.Criterion.Strategy
{
    public class FirstCriterion : IStrategy
    {
        public Family ApplyCriterion(Family family)
        {
            if (family is { Income: <= 900 })
            {
                family.Score += 5;
                return family;
            }
            return family;
        }
    }
}
