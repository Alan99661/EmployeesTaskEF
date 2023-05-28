using EmployeeTask.Database;
using EmployeeTask.Database.Configuring.Mapper;
using EmployeeTask_Services.Constracts;
using EmployeeTask_Services.Cruds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<EmployeeTaskDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MapperConfiguration));
builder.Services.AddScoped<IEmployeeCrudOperations, EmployeeCrudOperations>();
//builder.Services.AddScoped<ITaskCrudOperations,TaskCrudOperations>();
//builder.Services.AddScoped<IMeetingCrudOperations, MeetingCrudOperations>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
