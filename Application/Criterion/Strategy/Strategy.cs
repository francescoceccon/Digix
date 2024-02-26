
using Application.Criterion.Strategy.Interfaces;
using Domain.DTO;
using Domain.Entities;

namespace Application.Criterion.Strategy
{
    public class Strategy 
    {
        private readonly IStrategy _strategy;
        public static IEnumerable<Family> Families { get; private set; }

        public Strategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ApplyCriterionStrategy(IEnumerable<Family> family)
        {
            Parallel.ForEach(family, f => {
                _strategy.ApplyCriterion(f);
            });

            Families = family;
        }
    }
}
