using EcommerceAPI.DAL;
using EcommerceAPI.Entities.Auth;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using JwtTokenOption = EcommerceAPI.Entities.Auth.TokenOption;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<EcommerceDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    var tokenOption = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey)),
        ClockSkew = TimeSpan.Zero

    };

});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<EcommerceDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

