using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.Repositories;
using Entity.Repositories;
using HospitalApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi
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
            services.AddDbContext<ProjeDbContext>(_dbContext => _dbContext.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly(typeof(ProjeDbContext).Assembly.FullName)));
            services.AddRazorPages();

            services.AddScoped<IUnýtOfWork, UnýtOfWork>();

            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IPoliklinikService, PoliklinikService>();
            services.AddScoped<GenericHelperMethods>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters{ 
                ValidateAudience=true,//Token deðerini kimlerin-hangi uygulamalarýn kullanacaðýný belirler.
                ValidateIssuer=true,//Oluþturulan token deðerini kim daðýtmýþtýr.
                ValidateLifetime=true,//Oluþturulan token deðerinin yaþam süresidir.
                ValidateIssuerSigningKey=true,//Üretilen token deðerinin uygulamamýza ait olup olmadýðýna bakar.
                ValidIssuer=Configuration["Token:Ýssuer"], //yukarýdaki datanýn deðerini appsettigngsten almamýzý saðlar.
                ValidAudience=Configuration["Token:Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                ClockSkew=TimeSpan.Zero     //token süresinin uzatýlmasýný saðlar.
            });
            services.AddMvc().AddRazorPagesOptions(opt => opt.Conventions.AddPageRoute("/Login",""));//Login Anasayfa Olmasý Ýçin Yaptýk.
            services.AddControllers();
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
      
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
