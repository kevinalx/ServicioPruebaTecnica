using Microsoft.AspNetCore;
using ServicioPruebaTecnica;

var builder = WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices(services =>
    {
        services.AddIdentityServer()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients)
            .AddDeveloperSigningCredential();
    })
    .ConfigureLogging(logging =>
    {
        logging.AddDebug();
        logging.AddConsole();
    })
    .UseKestrel();

var host = builder.Build();

host.Run();
