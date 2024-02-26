using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Criterion.ChainOfResponsabilty
{
    public class ThirdCriteriaChain : IChain
    {
        public IChain Next { get ; set ; } = new FourthCriteriaChain();

        public Family ApplyCriterionChain(Family family)
        {
            if (family.Children.Count >= 3 && family.Children.Exists(x => x.Age > 18))
            {
                family.Score += 3;
                return Next.ApplyCriterionChain(family);

            }
            return Next.ApplyCriterionChain(family);
        }
    }
}
