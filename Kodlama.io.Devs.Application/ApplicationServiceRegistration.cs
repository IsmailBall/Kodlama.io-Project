using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kodlama.io.Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddMediatR(Assembly.GetExecutingAssembly());
            serviceDescriptors.AddAutoMapper(Assembly.GetExecutingAssembly());

            serviceDescriptors.AddScoped<LanguageBusinessRules>();

            serviceDescriptors.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceDescriptors.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return serviceDescriptors;

        }
    }
}
