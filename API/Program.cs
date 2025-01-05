using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Interfaces;
using API.Services;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();

bld.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(bld.Configuration.GetConnectionString("WebApiDatabase"));
});

bld.Services.AddScoped<IGymService, GymService>();


var app = bld.Build();
app.UseFastEndpoints();
app.Run();