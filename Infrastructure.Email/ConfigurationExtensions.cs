using System;
using System.Net.Mail;
using Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Email
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureFluentEmail(this IServiceCollection collection, string host, int port, bool enableSsl, string defaultFromEmail)
        {
            collection.AddTransient<IEmailService, FluentEmailManager>();
            collection
                .AddFluentEmail(defaultFromEmail)
                .AddRazorRenderer()
                .AddSmtpSender(() => new SmtpClient(host)
                {
                    EnableSsl = enableSsl,
                    Port = port,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                });

            return collection;
        }
    }
}
