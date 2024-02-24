using AuthenticateAPI.Data;
using AuthenticateAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<IdentityDBContext>(
    options => options.UseInMemoryDatabase("AuthenticateDb"));

builder.Services.AddDbContext<SecurityDbContext>(
    options => options.UseInMemoryDatabase("SecurityDb"));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<SecurityDbContext>();


   

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapIdentityAPI<IdentityUser>();
//app.MapIdentityAPI<IdentityUser>();
app.MapIdentityApi<AppUser>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
