using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderProcess.Models;

namespace OrderProcess;

public class OrderProcessor
{
    private readonly ILogger<OrderProcessor> _logger;

    public OrderProcessor(ILogger<OrderProcessor> logger)
    {
        _logger = logger;
    }

    public void ProcessOrder(Order order)
    {
        _logger.LogInformation($"Starting to process order {order.Id} for {order.CustomerName}");
        try
        {
            if (order.Amount <= 0)
            {
                throw new InvalidOperationException("Order amount should be more than zero.");
            }

            order.IsProcessed = true;
            _logger.LogInformation($"Order {order.Id} processed successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occured when processing order {order.Id}");
        }
    }
}
