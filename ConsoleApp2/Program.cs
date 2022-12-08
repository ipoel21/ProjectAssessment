// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using ConsoleApp2.Apps;
using ConsoleApp2.Helpers;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder().ConfigureServices((builder) =>
{
    builder.AddSingleton<Student, Student>();
    builder.AddSingleton<StudentGrade>();
    builder.AddSingleton<Teacher>();
    builder.AddSingleton<Subject>();
    builder.AddSingleton<Class>();
    builder.AddSingleton<Application>();
    builder.AddSingleton<StudentApp>();
    builder.AddSingleton<TeacherApp>();
}).Build();

var app = host.Services.GetRequiredService<Application>();
app.Run();