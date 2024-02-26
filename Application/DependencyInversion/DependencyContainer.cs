using Application.UseCases;
using Domain.Entities;
using Infrastructure.Repository;
using Infrastructure.Repository.Contexts;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInversion
{
    public static class DependencyContainer
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddSingleton<ICriterionUseCase, CriterionUseCase>();
            services.AddSingleton<IBaseRepository<Family>, FamilyRepository>();
            services.AddSingleton<IBaseRepository<Person>, PersonRepository>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
            });
        }
    }
}
