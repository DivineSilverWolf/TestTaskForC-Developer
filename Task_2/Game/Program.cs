using Game;
using Game.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appSettings.json", false, false).Build();
var serviceProvider = new ServiceCollection().UseStartup<Startup>(configuration).BuildServiceProvider();
var runner = serviceProvider.GetRequiredService<IApplicationRunner>();
runner.Run();