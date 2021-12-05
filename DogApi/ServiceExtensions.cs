using AspNetCoreRateLimit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi
{
    public static class ServiceExtensions
    {

        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit= 5,
                    Period = "20s"
                }
            };

            var response = new QuotaExceededResponse
            {
                Content = "{{\"message\" : \"429 Too Many Requests\"}}",
                ContentType = "application/json"
            };


            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
                opt.QuotaExceededResponse = response;
                
             
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

    }

}
