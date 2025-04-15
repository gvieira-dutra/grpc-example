var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddGrpc();
builder.Services.AddDbContext<AllergenCheckContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Database"));
});
var app = builder.Build();

app.MapDefaultEndpoints();

app.UseSqliteMigration();
app.MapGrpcService<AllergenCheckService>();

app.MapGet(
    "/",
    () =>
        "Grpc endpoints must receive communication from Grpc clients. To learn more visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
