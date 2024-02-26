using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Criterion.Strategy
{
    public class ThirdCriteria : IStrategy
    {
        public Family ApplyCriterion(Family family)
        {
            if (family.Children.Count >= 3 && family.Children.Exists(x => x.Age > 18))
            {
                family.Score += 3;
                return family;

            }
            return family;
        }
    }
}
