using Microsoft.EntityFrameworkCore;
using TTRPGOrganizer.Data;
using TTRPGOrganizer.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var connectionString = Environment.GetEnvironmentVariable("NeonConnection") ?? builder.Configuration.GetConnectionString("NeonConnection");
builder.Services.AddScoped<OrganizerContext>();
builder.Services.AddDbContext<OrganizerContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrganizerContext>();
    await dbContext.Database.MigrateAsync(); 
}

app.MapCampaignsEndpoints();
app.MapRpgSystemEndpoints();
app.MapGet("/", () => "Hello World!");

app.Run();