using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.WebApi.Application.Services;
using Sample.WebApi.ServiceHost.Infrastructure;

namespace Sample.WebApi.ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //
            // Sevice Types Example (Transient vs Scoped vs Singleton)
            // 
            // Transient = Everytime a service is requested create a new version
            // Scoped = For every new scope (think REST call), create a new version.  When asked for 
            //          subsequent times in the same Scope, the same instance is returned.
            // Singleton = Spin on a Single instance for the entire app
            // 
            services.AddTransient<IOCEntry>();
            services.AddTransient<TransiantValue>();
            services.AddScoped<ScopedValue>();
            services.AddSingleton<SingletonValue>();


            // Add a "Scoped" object called CallContext to create a unique Transaction ID per API Hit
            services.AddScoped<CallContext>();

            //
            // Setup MediatR which allows us to implement a Mediator Pattern for service routing, this kind
            // Of decoupling the Api implementation from logic allows for easier testing/mocking.
            //
            // Reference:  https://github.com/jbogard/MediatR
            //
            services.AddMediatR(typeof(Startup).Assembly, typeof(Application.Responses.Response).Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
