using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Repository;
using SWD392_PracinicalManagement.Service;

var builder = WebApplication.CreateBuilder(args);

//DUNGMV add
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SWD392_FinalProjectContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IPracinicalCategoryRepository, PracinicalCategoryRepository>();
builder.Services.AddTransient<IPracinicalServiceRepository, PracinicalServiceRepository>();
builder.Services.AddTransient<IExaminationResultRepository, ExaminationResultRepository>();
builder.Services.AddTransient<IExaminationFormRepository, ExaminationFormRepository>();
builder.Services.AddTransient<IMedicalRecordRepository, MedicalRecordRepository>();

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IPracinicalCategoryService, PracinicalCategoryService>();
builder.Services.AddTransient<IPracinicalServiceService, PracinicalServiceService>();
builder.Services.AddTransient<IExaminationResultService, ExaminationResultService>();
builder.Services.AddTransient<IExaminationFormService, ExaminationFormService>();
builder.Services.AddTransient<IMedicalRecordService, MedicalRecordService>();

builder.Services.AddSession();
builder.Services.AddRazorPages();
//DUNGMV add

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapRazorPages();
app.Run();
