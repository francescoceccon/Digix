using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Application.Criterion.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Criterion.ChainOfResponsabilty
{
    public class SecondCriteriaChain : IChain
    {
        public IChain Next { get ; set ; } 

        public Family ApplyCriterionChain(Family family)
        {
            if (family is { Income: >= 901 and <= 1500 })
            {
               family.Score += 3;
                return Next.ApplyCriterionChain(family);

            }
            return Next.ApplyCriterionChain(family);
        }
    }
}
