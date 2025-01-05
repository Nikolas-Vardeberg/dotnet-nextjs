using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using API.Data;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();

bld.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(bld.Configuration.GetConnectionString("WebApiDatabase"));
});

var app = bld.Build();
app.UseFastEndpoints();
app.Run();