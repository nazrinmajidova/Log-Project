using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrderProcess.Models;
using OrderProcess;



 var serviceProvider = new ServiceCollection()
     .AddLogging(config =>
     {
         config.AddConsole();
         config.SetMinimumLevel(LogLevel.Information);
     })
     .AddTransient<OrderProcessor>()
     .BuildServiceProvider();


 var logger = serviceProvider.GetService<ILogger<Program>>();

 logger.LogInformation("Application started.");


 var orders = new List<Order>
 {
     new Order { Id = 1, CustomerName = "Leyla", Amount = 50 },
     new Order { Id = 2, CustomerName = "Ehmed", Amount = 0 }, 
     new Order { Id = 3, CustomerName = "Cavidan", Amount = 150 }
 };


 var orderProcessor = serviceProvider.GetService<OrderProcessor>();
 foreach (var order in orders)
 {
     orderProcessor.ProcessOrder(order);
 }

 logger.LogInformation("Application finished.");