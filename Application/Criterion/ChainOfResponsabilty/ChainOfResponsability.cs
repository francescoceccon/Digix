
using Application.Criterion.ChainOfResponsabilty.Interfaces;
using Domain.Entities;

namespace Application.Criterion.ChainOfResponsabilty
{
    public class ChainOfResponsability : IChain
    {
        public IChain Next { get; set; } = new FirstCriterionChain();
        public static IEnumerable<Family> Families { get; private set; }

        public Family ApplyCriterionChain(Family family)
        {
            return Next.ApplyCriterionChain(family);
        }
        
        public void CallCriterionChain(IEnumerable<Family> family)
        {
            Parallel.ForEach(family, f => {
                this.ApplyCriterionChain(f);
            });

            Families = family;
        }
    }
}
