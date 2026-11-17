using Microsoft.Extensions.DependencyInjection;
using OSK.Petra.Experiences;

namespace OSK.Petra.Godot.Experiences;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the experience service and dependencies for Godot
    /// </summary>
    /// <param name="services">The services to add the dependencies ot</param>
    /// <returns>The services for chaining</returns>
    public static IServiceCollection AddGodotExperiences(this IServiceCollection services)
    {
        services.AddExperiences();

        return services;
    }
}
