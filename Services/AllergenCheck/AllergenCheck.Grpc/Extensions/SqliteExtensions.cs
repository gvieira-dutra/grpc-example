namespace AllergenCheck.Grpc.Extensions;

public static class SqliteExtensions
{
    public static IApplicationBuilder UseSqliteMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AllergenCheckContext>();
        context.Database.Migrate();

        return app;
    }
}
