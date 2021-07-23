using CreditCardApi.Domain.Models;
using CreditCardApi.Repositories;
using CreditCardApi.Services;
using CreditCardApi.Services.Commands;
using CreditCardApi.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection;

namespace CreditCardApi
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
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<IInputRepository, InputRepository>();
            services.AddScoped<IInputService, InputService>();
            services.AddDbContext<InputContext>(opt => opt.UseInMemoryDatabase("InputStorage"));
            
            services.AddTransient<IRequestHandler<CreateNewInputCommand, Input>, CreateNewInputCommandHandler>();
            services.AddTransient<IRequestHandler<GetInputByIdQuery, Input>, GetInputByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetInputsQuery, List<Input>> , GetInputsQueryHandler>();

            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
