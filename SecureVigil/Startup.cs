using System.Globalization;
using System.Security.Claims;
using System.Text;
using SecureVigil.DAL;
using SecureVigil.WebApp.Authentication;
using SecureVigil.WebApp.Controllers;
using SecureVigil.WebApp.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace SecureVigil.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddMvc();
            services.AddSingleton(_ => new UserGateway(Configuration["ConnectionStrings:SecureVigilDB"] ));
            services.AddSingleton(_ => new ClientGateway(Configuration["ConnectionStrings:SecureVigilDB"] ));                        
            services.AddSingleton(_ => new ContratGateway(Configuration["ConnectionStrings:SecureVigilDB"] ));                        
            services.AddSingleton(_ => new ZoneGateway(Configuration["ConnectionStrings:SecureVigilDB"] ));                        
            services.AddSingleton(_ => new MissionGateway(Configuration["ConnectionStrings:SecureVigilDB"] ));                        
            services.AddSingleton(_ => new VigilGeteway(Configuration["ConnectionStrings:SecureVigilDB"] ));                        

            services.AddSingleton<PasswordHasher>();
            services.AddSingleton<UserService>();
            services.AddSingleton<TokenService>();


            string secretKey = Configuration["JwtBearer:SigningKey"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.Configure<TokenProviderOptions>(o =>
            {
                o.Audience = Configuration["JwtBearer:Audience"];
                o.Issuer = Configuration["JwtBearer:Issuer"];
                o.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.Configure<SpaOptions>(o =>
            {
                o.Host = Configuration["Spa:Host"];
            });

            services.AddAuthentication(CookieAuthentication.AuthenticationScheme)
                .AddCookie(CookieAuthentication.AuthenticationScheme, o =>
                {
                    o.ExpireTimeSpan = TimeSpan.FromHours(1);
                    o.SlidingExpiration = true;
                })
                .AddJwtBearer(JwtBearerAuthentication.AuthenticationScheme, o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JwtBearer:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["JwtBearer:Audience"],

                        NameClaimType = ClaimTypes.Email,
                        AuthenticationType = JwtBearerAuthentication.AuthenticationType,

                        ValidateLifetime = true
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowCredentials();
                c.WithOrigins(Configuration["Spa:Host"]);
            });

            string secretKey = Configuration["JwtBearer:SigningKey"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Account", action = "Login" });
            });

            app.UseStaticFiles();
        }
    }
}

