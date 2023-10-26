using DepositManager.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

namespace DepositManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSyncfusionBlazor();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc2MDU1MUAzMjMzMmUzMDJlMzBCc3YzOTJkTjBncEw1RDNzWitpWkF3Z0xhTUNCaG5YOUs2eEZPbUhhYVlzPQ==");
            builder.Services.AddScoped<SfDialogService>();
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddDbContext<MyDbContext>(opt =>
            {
                opt.UseSqlite("Data Source = MyData.db");
                opt.EnableSensitiveDataLogging();
            });

            builder.Services.AddScoped<DepositServices>();
            builder.Services.AddScoped<CheckServices>();
            builder.Services.AddScoped<BankServices>();
            builder.Services.AddScoped<EmailServices>();
            builder.WebHost.UseUrls("http://*:6428");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseRouting();
            app.MapControllers();
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
