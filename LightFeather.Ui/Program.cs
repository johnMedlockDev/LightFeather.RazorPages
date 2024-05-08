namespace LightFeather.Ui;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        _ = builder.Services.AddRazorPages();
        _ = builder.Services.AddHttpClient();

        _ = builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenAnyIP(80);
            serverOptions.ListenAnyIP(443);
        });

        var app = builder.Build();

        _ = app.UseExceptionHandler("/Error");
        _ = app.UseHsts();

        _ = app.UseHttpsRedirection();
        _ = app.UseStaticFiles();

        _ = app.UseRouting();

        _ = app.UseAuthorization();

        _ = app.MapRazorPages();

        app.Run();
    }
}