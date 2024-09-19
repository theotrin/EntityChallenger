using EntityChallenger.Data;
using EntityChallenger.Model;
using EntityChallenger.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration.GetConnectionString("AdminConnection");
builder.Services.AddDbContext<AdminDbContext>(
    opts =>
    {
        opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
    });

builder.Services.AddAutoMapper(AppDomain
    .CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<Admin, IdentityRole>()
    .AddEntityFrameworkStores<AdminDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<AdminServices>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddControllers();
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
