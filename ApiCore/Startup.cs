

namespace ApiCore {
    using JWT.Authentication;
    using ApiDataAccess;
    using ApiUnitWork;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Logging;
    using ApiBussinessLogic.Interfaces;
    using ApiBussinessLogic.Implementations;
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
                services.AddTransient<IRolLogic,RolLogic>();
                services.AddTransient<IUserLogic,UserLogic>();
                services.AddTransient<IRolUserLogic,RolUserLogic>();
                services.AddTransient<ITokenLogic,TokenLogic>();
                services.AddTransient<IPersonalReferenceLogic,PersonalReferenceLogic>();
                services.AddTransient<IKgValueLogic,KgValueLogic>();
                services.AddTransient<ISizeValueLogic,SizeValueLogic>();
                services.AddTransient<IStatusNutritionGeneralLogic,StatusNutritionGeneralLogic>();
                services.AddTransient<IGradeLogic,GradeLogic>();
                services.AddSingleton<IUnitOfWork> (option => new UnitOfWork (
                    //Configuration.GetConnectionString ("local")
                    Configuration.GetConnectionString ("local")
            ));
            var tokenProvider = new JwtProvider ("issuer", "audience", "profexorrr_20000");
            services.AddSingleton<ITokenProvider> (tokenProvider);
            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (options => {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters ();
                });
        

            services.AddAuthorization (auth => {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder ()
                    .AddAuthenticationSchemes (JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser ()
                    .Build ();
            });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_3_0);
            services.AddMvc (option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage ();
                IdentityModelEventSource.ShowPII = true;
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            // CORS
            // https://docs.asp.net/en/latest/security/cors.html
            //app.UseHttpsRedirection ();
            app.UseCors (builder =>
                builder.WithOrigins ("http://localhost:4200", "https://fundacion-ddaa7.web.app/")
                .AllowAnyHeader ()
                .AllowAnyMethod ());
            
            app.UseAuthentication ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();
            app.UseMvc ();

        }
    }
}