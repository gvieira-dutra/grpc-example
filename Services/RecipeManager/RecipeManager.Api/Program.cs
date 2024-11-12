using AllergenService.Grpc;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("recipemanager-db")!);
    config.Schema.For<Recipe>().Identity(s => s.RecipeName);
})
.UseLightweightSessions();

builder.Services.AddScoped<IRecipeManagerRepository, RecipeManagerRepository>();

builder.Services.AddGrpcClient<AllergenCheckProtoService.AllergenCheckProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:AllergenCheckerUrl"]!);
});

var app = builder.Build();

app.MapDefaultEndpoints();
app.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
