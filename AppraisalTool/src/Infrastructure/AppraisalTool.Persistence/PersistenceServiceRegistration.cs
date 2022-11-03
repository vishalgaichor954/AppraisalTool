using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Infrastructure.EncryptDecrypt;
using AppraisalTool.Persistence.Repositories;
using AppraisalTool.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppraisalTool.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<ISelfAppraisalRepository, SelfAppraisalRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IMetricRepository, MetricRepository>();
            services.AddScoped<IAppraisalResultRepository, AppraiasalResultRepository>();

            return services;
        }
    }
}
