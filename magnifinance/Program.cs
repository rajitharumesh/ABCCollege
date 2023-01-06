using Domain.UnitOfWork;
using Infrastructure;
using Infrastructure.UnitOfWork;
using magnifinance.Services;
using magnifinance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(ICourseService), typeof(CourseService));
builder.Services.AddTransient(typeof(ISubjectService), typeof(SubjectService));
builder.Services.AddTransient(typeof(ITeacherService), typeof(TeacherService));
builder.Services.AddTransient(typeof(IStudentService), typeof(StudentService));

//Database
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ABCCollegeDbContext>(
               x => x.UseSqlServer(builder.Configuration.GetConnectionString("ABCCollegeConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;
app.UseDeveloperExceptionPage();
app.Run();
