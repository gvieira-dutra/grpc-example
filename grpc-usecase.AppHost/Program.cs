var builder = DistributedApplication.CreateBuilder(args);

var recipeManagerDb = builder.AddPostgres("recipemanager-db")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.RecipeManager_Api
    >("recipemanager-api")
    .WithReference(recipeManagerDb);

builder.AddProject<Projects.AllergenCheck_Grpc>("allergencheck-grpc");

builder.Build().Run();
