using Learn.Util;
using Learn.Util.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders; 
using Microsoft.Extensions.Options; 
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Learn.Web.Controllers;
using UEditor.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization; 
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;

namespace Learn.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationRoot ConfigurationRoot { get; }

        public IHostingEnvironment Env { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.Env = env;
            LogHelper.Configure(); //ʹ��ǰ������
            GlobalContext.LogWhenStart(env); 
            GlobalContext.HostingEnvironment = env; 
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                                                    .AddEnvironmentVariables();
          ConfigurationRoot = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container. 
        //IServiceProvider
        public void ConfigureServices(IServiceCollection services)
        {
            //��Redis�ֲ�ʽ���������ӵ�������
            //services.AddDistributedRedisCache(options =>
            //{
            //    //��������Redis������  Configuration.GetConnectionString("RedisConnectionString")��ȡ������Ϣ�Ĵ�
            //    options.Configuration = "localhost";// Configuration.GetConnectionString("RedisConnectionString");
            //    //Redisʵ����RedisDistributedCache
            //    options.InstanceName = "RedisDistributedCache";
            //});
            services.AddCors(c =>
            {  
                //һ��������ַ���
                c.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    // ֧�ֶ�������˿ڣ�ע��˿ںź�Ҫ��/б�ˣ�����localhost:8000/���Ǵ��
                    // ע�⣬http://127.0.0.1:1818 �� http://localhost:1818 �ǲ�һ���ģ�����д����
                    policy
                    .WithOrigins("http://127.0.0.1", "http://localhost")
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
           
            services.AddUEditorService();
            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            // ȡ��Ĭ���շ� System.Text.Json��ʽ
            .AddJsonOptions(options => { 
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            //NewtonsoftJson ��ʽ 
            //AddNewtonsoftJson(options =>   options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(GlobalContext.HostingEnvironment.ContentRootPath + Path.DirectorySeparatorChar + "DataProtection"));
            services.AddRazorPages();
            GlobalContext.Services = services;
            GlobalContext.ServiceProvider = services.BuildServiceProvider();
            GlobalContext.Configuration = Configuration;


            var builder = new ContainerBuilder();
            services.AddSingleton(new Appsettings(Env));

            //////��services��䵽Autofac������������
            //builder.Populate(services);
            //////ʹ���ѽ��е�����ǼǴ���������
            //var ApplicationContainer = builder.Build();
            //return new AutofacServiceProvider(ApplicationContainer);//������IOC�ӹ� core����DI����
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            GlobalContext.SystemConfig = Configuration.GetSection("SystemConfig").Get<SystemConfig>();
            if (!string.IsNullOrEmpty(GlobalContext.SystemConfig.VirtualDirectory))
            {
                app.UsePathBase(new PathString(GlobalContext.SystemConfig.VirtualDirectory)); // �� Pathbase �м����Ϊ��һ������������м���� ������ȷ��ģ������·��
            }
            if (env.IsDevelopment())
            {
                GlobalContext.SystemConfig.Debug = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            #region ʵ�ֿ��� 
            app.UseCors("AllowSpecificOrigins");
            #endregion
            // ��תhttps
            //app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            string resource = Path.Combine(env.ContentRootPath, "Resource");
            if (!Directory.Exists(resource))
            {
                Directory.CreateDirectory(resource);
            }
            //app.UseSession();


            //��̬�ļ�ע��
            app.UseStaticFiles();
            //�Զ��徲̬�ļ��� �������ļ�
            var provider = new FileExtensionContentTypeProvider();
            //provider.Mappings.Remove("gif");
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"upload")),
                RequestPath = new PathString("/upload"),
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
                },
                ContentTypeProvider = provider
            }); ;
            ////���þ�̬�ļ�Ŀ¼����
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/MyStaticFiles")
            //});
            ////UseFileServer�Ĺ��ܽ����UseStaticFiles��UseDefaultFiles��UseDirectoryBrowser��
            //app.UseFileServer(new FileServerOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/StaticFiles"),
            //    EnableDirectoryBrowsing = true
            //});


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapHub<ChatHub>("/api2/chatHub");
            });
        }

        /// <summary>
        /// ���򷽷�
        /// </summary>
        /// <param name="services"></param>
        //private void OptionConfigure(IServiceCollection services)
        //{
        //    services.Configure<CorsOptions>(Configuration.GetSection("AllowedHosts"));
        //}
    }
}
