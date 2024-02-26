
using Application.Criterion.ChainOfResponsabilty;
using Application.Criterion.Strategy;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;

namespace Application.UseCases
{
    public class CriterionUseCase : ICriterionUseCase
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Family> _repository;

        public CriterionUseCase(IMapper mapper,IBaseRepository<Family> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task InsertFamilyAsync(Family family)
        {
            await _repository.Insert(family);
        }

        public async Task<IEnumerable<FamilyDTO>> ApplyCriterionStrategyAsync()
        {
            var families = await _repository.SelectList();

            families = families.SkipWhile(f => f.AlreadyScored is true);

            new Strategy(new FirstCriterion()).ApplyCriterionStrategy(families);
            new Strategy(new SecondCriteria()).ApplyCriterionStrategy(families);
            new Strategy(new ThirdCriteria()).ApplyCriterionStrategy(families);
            new Strategy(new FourthCriteria()).ApplyCriterionStrategy(families);

            return Sort(Strategy.Families);
        }

        public async Task<IEnumerable<FamilyDTO>> ApplyCriterionChainAsync()
        {
            var families = await _repository.SelectList();

            new ChainOfResponsability().CallCriterionChain(families.SkipWhile(f=> f.AlreadyScored is true));

            return Sort(Strategy.Families);
        }

        private IEnumerable<FamilyDTO> Sort(IEnumerable<Family> familys)
        {
            var dtoList = new List<FamilyDTO>();    
            foreach (var item in familys)
            {
                dtoList.Add( _mapper.Map<Family, FamilyDTO>(item) );
            }
            dtoList.Sort((first,second) => first.Income.CompareTo(second.Income));

            return dtoList;
        }
    }
}
