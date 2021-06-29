using GoatPortfolio.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GoatPortfolio
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAuthentication("Identity.Application").AddCookie();
            services.AddHttpContextAccessor();

            //services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            //{
            //    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
            //    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            //});

            //services.AddAuthentication().AddTwitter(twitterOptions =>
            //{
            //    twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
            //    twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            //    twitterOptions.RetrieveUserDetails = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, System.IServiceProvider services)
        {
          //  if (env.IsDevelopment())
          //  {
                app.UseDeveloperExceptionPage();
                var dbContext = services.GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();
           // }
           // else
           // {
                app.UseExceptionHandler("/Error");
             //   var dbContext = services.GetService<ApplicationDbContext>();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
           // }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
