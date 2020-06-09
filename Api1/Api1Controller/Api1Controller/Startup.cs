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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Api1.Api1Model.Models;
using Api1.Api1Model.Data;

namespace Api1.Api1Controller
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
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
            });

            // InMemoryを使用する場合はこちら
            // services.AddDbContext<Api1Context>(options =>
            //         options.UseInMemoryDatabase(Configuration.GetConnectionString("Api1Context")));

            // SQLServerを使用する場合はこちら
            services.AddDbContext<Api1Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Api1Context")
                    ,x => x.MigrationsAssembly("Api1Migration")));

            // ODataのサービス構築
            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ODataのミドルウェア追加
            app.UseMvc(builder =>
            {
                builder.Select().Expand().Filter().OrderBy().Count();
                builder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api1 V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// ODataで使用するEdm(EntityDataModel)
        /// </summary>
        /// <returns></returns>
        private IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Blog>("Api1");
            builder.EntitySet<Post>("Post");
            return builder.GetEdmModel();
        }
    }
}
