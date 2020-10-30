using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.DataRepository;
using Splitwise.Repository.GroupMemberRepository;
using Splitwise.Repository.GroupRepository;
using Splitwise.Repository.UserRepository;
using Splitwise.Repository.UserFriendRepository;
using Splitwise.Repository.ExpenseRepository;
using Splitwise.Repository.PayeeRepository;
using Splitwise.Repository.PayerRepository;
using Splitwise.Repository.SettlementRepository;

namespace Splitwise.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
               .AddNewtonsoftJson(options =>
               {
                   var resolver = options.SerializerSettings.ContractResolver;
                   if (resolver != null)
                       (resolver as DefaultContractResolver).NamingStrategy = null;
               });
            services.AddControllersWithViews();

            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IGroupRepository, GroupsRepository>();
            services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
            services.AddScoped<IUserFriendRepository, UserFriendRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IPayerRepository, PayerRepository>();
            services.AddScoped<IPayeeRepository, PayeeRepository>();
            services.AddScoped<ISettlementRepository, SettlementRepository>();
            

            services.AddDbContext<SplitwiseDbContext>(options =>
            { 
                options.UseSqlServer(Configuration.GetConnectionString("Mystring"),
                    b => b.MigrationsAssembly("Splitwise.DomainModel"));
            });



            services.AddIdentity<Users, IdentityRole>()
                .AddEntityFrameworkStores<SplitwiseDbContext>();
            services.AddControllersWithViews();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

          // Adding Jwt Bearer  
          .AddJwtBearer(options =>
          {
              options.SaveToken = true;
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidAudience = Configuration["JWT:ValidAudience"],
                  ValidIssuer = Configuration["JWT:ValidIssuer"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
              };
          });

            var configuration = new AutoMapper.MapperConfiguration(config =>
            {
                config.CreateMap<Users, UsersAC>();
                config.CreateMap<Groups, GroupsAC>();
                config.CreateMap<GroupMember, GroupMemberAC>();
                config.CreateMap<UserFriend, UserFriendAC>();
                config.CreateMap<Expenses, ExpensesAC>();
                config.CreateMap<Payers, PayersAC>();
                config.CreateMap<Payees, PayeesAC>();
                config.CreateMap<Settlements, SettlementsAC>();
            });
            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
