namespace BatchProcessor;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("BatchProcessor activo. Esperando para el siguiente ciclo...");

            await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken); // Para demo: 1 minuto

            var batch = new List<string>() {"Data1","Data2"};

            if (batch.Count > 0)
            {
                _logger.LogInformation($"[BatchProcessor] Procesando {batch.Count} eventos:");
                foreach (var e in batch)
                {
                    _logger.LogInformation($" (Data Name) → {e}");
                }
            }
            else
            {
                _logger.LogInformation("[BatchProcessor] No hay eventos para procesar.");
            }
        }
    }
}
