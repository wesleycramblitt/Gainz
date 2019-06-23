using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GainzWebAPI.Models;
using AutoMapper.EquivalencyExpression;


namespace GainzWebAPI
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

            //Get connection string from Heroku Database Url
            Uri.TryCreate(Configuration["DATABASE_URL"], UriKind.Absolute, out Uri url);

            var connectionUrl = $"host={url.Host};username={url.UserInfo.Split(':')[0]};password={url.UserInfo.Split(':')[1]};database={url.LocalPath.Substring(1)};pooling=true;";

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkNpgsql();

            services.AddDbContext<GainzWebAPI.Models.GainzDBContext>(opt => opt.UseNpgsql(connectionUrl));

            services.BuildServiceProvider();

            //opt.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"));

            Mapper.Initialize(cfg =>  {
                cfg.AddCollectionMappers();
                cfg.CreateMap<Exercise, Exercise>().EqualityComparison((x, y) => x.ExerciseID == y.ExerciseID);
                cfg.CreateMap<Muscle, Muscle>().EqualityComparison((x, y) => x.ID == y.ID);
                cfg.CreateMap<ExerciseMuscle, ExerciseMuscle>().EqualityComparison((x, y) => x.ExerciseMuscleID == y.ExerciseMuscleID);
                cfg.CreateMap<Split, Split>().EqualityComparison((x, y) => x.ID== y.ID);
                cfg.CreateMap<SplitDay, SplitDay>().EqualityComparison((x, y) => x.ID == y.ID);
                cfg.CreateMap<DayMuscle, DayMuscle>().EqualityComparison((x, y) => x.ID == y.ID);
                cfg.CreateMap<Day, Day>().EqualityComparison((x, y) => x.ID == y.ID);
            });
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

            app.UseCors(o =>
            {
                o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
