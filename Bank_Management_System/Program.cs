using Bank_Management_System.AppDbContext;
using Bank_Management_System.Services.AccountRepository;
using Bank_Management_System.Services.BranchRepository;
using Bank_Management_System.Services.CustomerRepository;
using Bank_Management_System.Services.EmployeeRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connect = builder.Configuration.GetConnectionString("myconnection");
builder.Services.AddDbContext<dbcontext>(
    options => options.UseSqlServer(connect));


builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerRepo,CustomerRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IBranchRepo, BranchRepo>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
