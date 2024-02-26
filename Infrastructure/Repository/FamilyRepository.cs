using Domain.Entities;
using Infrastructure.Repository.Contexts;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FamilyRepository : IBaseRepository<Family>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IBaseRepository<Person> _personRepository;

        public FamilyRepository(ApplicationDbContext applicationDbContext,IBaseRepository<Person> personRepository)
        {
            _applicationDbContext = applicationDbContext;
            _personRepository = personRepository;
        }

        public async Task Insert(Family entity)
        {
            try
            {
                await _personRepository.Insert(entity.Holder);
                await _personRepository.Insert(entity.CoHolder);
                entity.Children.ForEach(async x => await _personRepository.Insert(x)); 

                _applicationDbContext.Families.Add(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Family>> SelectList()
        {
            try
            {
                return await _applicationDbContext.Families.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
