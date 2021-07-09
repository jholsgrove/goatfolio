using System;
using GoatPortfolio.Data;
using GoatPortfolio.Helpers;
using GoatPortfolio.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GoatPortfolio.Areas.Identity.IdentityHostingStartup))]
namespace GoatPortfolio.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

                services.AddTransient<IEmailSender, MailKitEmailSender>();
                services.Configure<MailKitEmailSenderOptions>(options =>
                {
                    options.Host_Address = context.Configuration.GetValue<string>("SendInBlue:HostAddress");
                    options.Host_Port = context.Configuration.GetValue<int>("SendInBlue:HostPort");
                    options.Host_Username = context.Configuration.GetValue<string>("SendInBlue:HostUserName");
                    options.Host_Password = context.Configuration.GetValue<string>("SendInBlue:HostPassword");
                    options.Sender_EMail = context.Configuration.GetValue<string>("SendInBlue:HostEmail");
                    options.Sender_Name = context.Configuration.GetValue<string>("SendInBlue:SenderName");
                });
            });
        }
    }
}