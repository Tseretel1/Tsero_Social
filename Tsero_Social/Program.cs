using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tsero_Social.Dbcontext;
using Tsero_Social.InterFaces;
using Tsero_Social.Models;
using Tsero_Social.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<NotificationsServices>();
builder.Services.AddScoped<INotification, NotificationsServices>();
builder.Services.AddScoped<UploadImg>();
builder.Services.AddScoped<IuploadImg, UploadImg>();
builder.Services.AddScoped<postService>();
builder.Services.AddScoped<IpostService, postService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<IuserService, UserServices>();
builder.Services.AddScoped<LikeCommentService>();
builder.Services.AddScoped<ILikeCommentService, LikeCommentService>();
builder.Services.AddScoped<Followserivce>();
builder.Services.AddScoped<IfollowService, Followserivce>();

builder.Services.AddDbContext<UserDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserConection")));
var app = builder.Build();


builder.Services.AddControllersWithViews();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
