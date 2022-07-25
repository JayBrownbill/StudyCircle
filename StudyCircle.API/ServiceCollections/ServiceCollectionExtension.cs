using StudyCircle.API.Repository;

namespace StudyCircle.API.ServiceCollections
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepoServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStudyTopicRepository, StudyTopicRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            return serviceCollection;
        }
    }
}
