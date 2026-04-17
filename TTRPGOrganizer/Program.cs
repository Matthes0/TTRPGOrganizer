using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TTRPGOrganizer.Data;
using TTRPGOrganizer.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var connectionString = Environment.GetEnvironmentVariable("NeonConnection") ?? builder.Configuration.GetConnectionString("NeonConnection");
builder.Services.AddScoped<OrganizerContext>();
builder.Services.AddDbContext<OrganizerContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<OrganizerContext>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrganizerContext>();
    await dbContext.Database.MigrateAsync(); 
}
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}
app.UseAuthentication();
app.UseAuthorization();

app.MapCampaignsEndpoints();
app.MapRpgSystemEndpoints();
app.MapCampaignMembersEndpoints();
app.MapGet("/", () => "Hello World!");
app.MapIdentityApi<IdentityUser>();
app.Run();