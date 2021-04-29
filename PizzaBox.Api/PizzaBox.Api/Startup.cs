using JsonSubTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Domain.Models.Toppings;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Api
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

            services.AddControllers();
            services.AddDbContext<PizzaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PizzaBox")));

            services.AddScoped<IRepository<ACrust>, RepositoryCrust>();
            services.AddScoped<IRepository<Customer>, RepositoryCustomer>();
            services.AddScoped<IRepository<Order>, RepositoryOrder>();
            services.AddScoped<IRepository<APizza>, RepositoryPizza>();
            services.AddScoped<IRepository<ASize>, RepositorySize>();
            services.AddScoped<IRepository<AStore>, RepositoryStore>();
            services.AddScoped<IRepository<ATopping>, RepositoryTopping>();


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of<ACrust>("CRUSTS") // type property is only defined here
                    .RegisterSubtype<DeepDishCrust>(CRUSTS.DEEPDISH)
                    .RegisterSubtype<StandardCrust>(CRUSTS.STANDARD)
                    .RegisterSubtype<StuffedCrust>(CRUSTS.STUFFED)
                    .RegisterSubtype<ThinCrust>(CRUSTS.THIN)
                    .SerializeDiscriminatorProperty() // ask to serialize the type property
                    .Build());

                options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of<APizza>("PIZZAS")
                    .RegisterSubtype<CustomPizza>(PIZZAS.CUSTOM)
                    .RegisterSubtype<MeatPizza>(PIZZAS.MEAT)
                    .RegisterSubtype<HawaiianPizza>(PIZZAS.HAWAIIAN)
                    .RegisterSubtype<VeganPizza>(PIZZAS.VEGAN)
                    .SerializeDiscriminatorProperty() // ask to serialize the type property
                    .Build());

                options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of<ASize>("SIZES")
                    .RegisterSubtype<SmallSize>(SIZES.SMALL)
                    .RegisterSubtype<MediumSize>(SIZES.MEDIUM)
                    .RegisterSubtype<LargeSize>(SIZES.LARGE)
                    .SerializeDiscriminatorProperty()
                    .Build());

                options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of<AStore>("STORES")
                    .RegisterSubtype<NewYorkStore>(STORES.NEWYORK)
                    .RegisterSubtype<ChicagoStore>(STORES.CHICAGO)
                    .SerializeDiscriminatorProperty()
                    .Build());

                options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of<ATopping>("TOPPINGS")
                    .RegisterSubtype<Bacon>(TOPPINGS.BACON)
                    .RegisterSubtype<Chicken>(TOPPINGS.CHICKEN)
                    .RegisterSubtype<ExtraCheese>(TOPPINGS.EXTRACHEESE)
                    .RegisterSubtype<GreenPepper>(TOPPINGS.GREENPEPPER)
                    .RegisterSubtype<Ham>(TOPPINGS.HAM)
                    .RegisterSubtype<NoCheese>(TOPPINGS.NOCHEESE)
                    .RegisterSubtype<Pineapple>(TOPPINGS.PINEAPPLE)
                    .RegisterSubtype<RedPepper>(TOPPINGS.REDPEPPER)
                    .RegisterSubtype<Sausage>(TOPPINGS.SAUSAGE)
                    .SerializeDiscriminatorProperty()
                    .Build());
            }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaBox.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaBox.Api v1"));
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
