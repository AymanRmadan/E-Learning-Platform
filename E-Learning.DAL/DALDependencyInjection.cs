
namespace E_Learning.DAL
{
    public static class DALDependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenaricRepository<,>), typeof(GenaricRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
