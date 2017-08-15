using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Gqlpoc.Database.Repositories;
using Gqlpoc.Web.Query;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using NPoco;
using DatabaseContext = NPoco.Database;
using System.Data.Common;

namespace Gqlpoc.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }   
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<DbConnection>(s => new SqliteConnection(Configuration["connectionStrings:sqlite"]));
            services.AddScoped<IDatabase, DatabaseContext>();
            services.AddScoped<IArtistRepository, SqliteArtistRepository>();
            
            this.ConfigureGqlTypes(services);
        }

        protected virtual void ConfigureGqlTypes(IServiceCollection services) 
        {
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.Scan(scan => 
                scan.FromEntryAssembly()
                    .AddClasses(classes => classes.AssignableTo<IInterfaceGraphType>())
                    .AsMatchingInterface()
                    .WithScopedLifetime()
            );

            var provider = services.BuildServiceProvider();
            var schemaTypes = provider.GetServices<IInterfaceGraphType>();

            services.AddScoped<MusicQuery>();
            services.AddScoped<ISchema>(_ => new MusicSchema(provider.GetService<MusicQuery>(), schemaTypes.ToArray()));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
