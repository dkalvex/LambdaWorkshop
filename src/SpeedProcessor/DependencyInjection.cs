using Microsoft.Extensions.DependencyInjection;
using SpeedProcessor.Services;

namespace LambdaWorkshop.SpeedProcessor;
public static class DependencyInjection
{
    public static IServiceCollection AddLambdaWorkshopService(this IServiceCollection services)
    {
        //MEDIATR CONFIG
        services.AddMediatR(mediatr =>
        {
            //Add all IRequestHandlers defined in this API
            mediatr.RegisterServicesFromAssembly(LambdaWorkshopAssemblyReference.Assembly);
        });

        
        services.AddHostedService<KafkaConsumerService>();
        
        return services;
    }
}