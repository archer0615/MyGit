using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ROG.Commons.Attributes;
using ROG.Commons.Extensions;
using ROG.Commons.ExternalAPI;
using ROG.Commons.Helpers;
using ROG.Commons.Middleware;
using ROG.Commons.SwaggerExtensions;
using ROG.DataDefine.Commons;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ROG
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile(path: $"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            #region IISOptions
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            #endregion

            #region 註冊Swagger服務
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Rog", new Info { Title = "Rog API", Version = "Rog" });
                c.SwaggerDoc("Elite", new Info { Title = "Elite", Version = "Elite" });
                c.SwaggerDoc("EliteAPI", new Info { Title = "EliteAPI", Version = "EliteAPI" });
                c.SwaggerDoc("RogSearch", new Info { Title = "RogSearch", Version = "RogSearch" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"rog.xml");
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<AuthorizationHeaderTokenOperationFilter>();
                c.DocumentFilter<RemoveVerbsFilter>();
                c.DescribeAllEnumsAsStrings();
            });
            #endregion

            #region DI Options
            services.Configure<AcountOptions>(Configuration.GetSection("AcountServiceSetting"));
            services.Configure<AccountServiceXMLOptions>(Configuration.GetSection("AccountServiceXMLSetting"));
            services.Configure<AccountLinkOptions>(Configuration.GetSection("AccountLink"));
            services.Configure<ExternalAPIOptions>(Configuration.GetSection("ExternalAPI"));
            services.Configure<ProjectConfigOptions>(Configuration.GetSection("ProjectConfig"));
            services.Configure<ROGSearchConfigOptions>(Configuration.GetSection("ROGSearchConfig"));
            services.Configure<EliteAPIConfigOptions>(Configuration.GetSection("EliteAPIConfig"));
            #endregion

            #region DI Common
            services.AddScoped<CrowdTwist_API_Url>();
            services.AddScoped<MiddleSystemHelper>();
            #endregion

            #region DI Dao & Service
            services.AddFromEntryAssembly(ServiceLifetime.Scoped, service => service.Name.EndsWith("Dao"));
            services.AddFromEntryAssembly(ServiceLifetime.Scoped, service => service.Name.EndsWith("Service"));
            #endregion

            //ApiToken
            services.AddScoped<ApiTokenFilterAttribute>();

            services.AddSingleton(Configuration);

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver
                        = new DefaultContractResolver();//帕斯卡命名
                });

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region DI Gzip壓縮
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression();
            //預設text/plain、text/css、application/javascript、text/html、application/xml、text/xml、application/json、text/json
            #endregion

            #region DI 跨網域白名單
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowCredentials();
                    //policy.WithOrigins("http://localhost:3000")
                    //      .AllowAnyHeader()
                    //      .AllowAnyMethod()
                    //      .AllowCredentials();
                });
            });
            #endregion

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            //});

            //services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);

            //services.AddSession(options =>
            //{
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");//跨網域middleware

            if (env.IsDevelopment() || env.IsEnvironment("local"))
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ConfigFile = "webpack/webpack.dev.js",
                    EnvParam = new { mode = "development" }
                });
            }

            app.UseResponseCompression();//Gzip壓縮

            app.UseMiddleware<ExceptionMiddleware>();//Exception Handle

            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            //    await next();
            //});

#if (DEBUG || MARS)
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Host = httpReq.Host.Value;
                    swaggerDoc.Schemes = new List<string>() { httpReq.Scheme };
                    swaggerDoc.BasePath = httpReq.PathBase;
                });
            });
            app.UseSwaggerUI(
                c =>
                {
                    c.DisplayRequestDuration();
                    c.SwaggerEndpoint("/swagger/Rog/swagger.json", "Rog");
                    c.SwaggerEndpoint("/swagger/RogSearch/swagger.json", "RogSearch");
                    c.SwaggerEndpoint("/swagger/Elite/swagger.json", "Elite");
                    c.SwaggerEndpoint("/swagger/EliteAPI/swagger.json", "EliteAPI");
                    c.InjectStylesheet("/swagger/ui/custom.css");
                });
#else
         app.UseMiddleware<ReleaseRouteMiddleware>();//排除Route以外的頁面
#endif

            //app.UseSession();

            app.UseDefaultFiles();
            app.UseStaticFiles();//靜態頁面

            app.UseMvc(routes =>
            {
                //順序不可換
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}