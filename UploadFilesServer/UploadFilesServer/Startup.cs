using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.IO;
using UploadFilesServer.Context;
using UploadFilesServer.Models;

namespace UploadFilesServer
{
    public class Startup
    {
        //private readonly IServiceCollection services;
        public Startup(IConfiguration configuration)//, IServiceCollection _services)
        {
            Configuration = configuration;
            //services = _services;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddEntityFrameworkNpgsql()
            //   .AddDbContext<UserContext>()
            //   .BuildServiceProvider();
            //services.AddEntityFrameworkNpgsql()
            //    .AddDbContext<UserContext>();
            //services.BuildServiceProvider().

            //            services.AddEntityFrameworkNpgsql();
            //            services.AddIdentity<User, IdentityRole>(). AddEntityFrameworkStores<UserContext>();

            //services.AddEntityFrameworkNpgsql().AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();
            //services.AddDbContext<UserContext>(opt=>opt.UseNpgsql("Username=root;Port=5432;Password=root;Host=172.18.0.2;Database=test;")).AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();
            //services.AddDbContext<UserContext>(opt=>opt.UseNpgsql("Username=root;Host=172.18.0.2;Port=5432;Password=root;Database=aaa;")).AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            //services.AddDbContext<UserContext>(opt=>opt.UseNpgsql(@"Server=172.18.0.2;Port=5432;Database=root;User Id=root;Password=root;")).AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();






            var connectionString = Configuration["Data:ConnectionStrings:PostgreConnectionString"];
            //var connectionString = Configuration["PostgreSql:Host = 172.18.0.2; Username = root; Database = root"];


            //var dbPassword = Configuration["PostgreSql:root"];

            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            //{
            //    Password = dbPassword
            //};

            services.AddDbContext<UserContext>(opt => opt.UseNpgsql(builder.ConnectionString));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();


            //optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=dbname;User Id=Id;Password=password");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
        }
    }
}
