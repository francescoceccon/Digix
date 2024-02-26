using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Criterion.ChainOfResponsabilty
{
    public class FourthCriteriaChain : IChain
    {
        public IChain Next { get; set; }

        public Family ApplyCriterionChain(Family family)
        {
            if ((family.Children.Count >= 1 || family.Children.Count >= 2) && family.Children.Exists(x => x.Age > 18))
            {
                family.Score += 2;
                return family;

            }
            return family;
        }
    }
}
