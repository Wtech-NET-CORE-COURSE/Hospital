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

            services.AddScoped<IUn�tOfWork, Un�tOfWork>();

            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IPoliklinikService, PoliklinikService>();
            services.AddScoped<GenericHelperMethods>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters{ 
                ValidateAudience=true,//Token de�erini kimlerin-hangi uygulamalar�n kullanaca��n� belirler.
                ValidateIssuer=true,//Olu�turulan token de�erini kim da��tm��t�r.
                ValidateLifetime=true,//Olu�turulan token de�erinin ya�am s�residir.
                ValidateIssuerSigningKey=true,//�retilen token de�erinin uygulamam�za ait olup olmad���na bakar.
                ValidIssuer=Configuration["Token:�ssuer"], //yukar�daki datan�n de�erini appsettigngsten almam�z� sa�lar.
                ValidAudience=Configuration["Token:Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                ClockSkew=TimeSpan.Zero     //token s�resinin uzat�lmas�n� sa�lar.
            });
            services.AddMvc().AddRazorPagesOptions(opt => opt.Conventions.AddPageRoute("/Login",""));//Login Anasayfa Olmas� ��in Yapt�k.
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
