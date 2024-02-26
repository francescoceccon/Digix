using Domain.Entities;
using Infrastructure.Repository.Contexts;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PersonRepository : IBaseRepository<Person>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Insert(Person entity)
        {
            try
            {
                _applicationDbContext.People.Add(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Person>> SelectList()
        {
            try
            {
                return await _applicationDbContext.People.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
