using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Criterion.Strategy
{
    public class SecondCriteria : IStrategy
    {
        public Family ApplyCriterion(Family family)
        {
            if (family is { Income: >= 901 and <= 1500 })
            {
               family.Score += 3;
                return family;

            }

            return family;
        }
    }
}
