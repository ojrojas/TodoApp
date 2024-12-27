namespace TodoApp.BuildingBlocks.Loggers;

public class LoggerApplicationService<T> : ILoggerApplicationService<T>
{
    private readonly ILogger<T> _logger;
    public LoggerApplicationService(ILogger<T> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void LogInformation(BaseResponse response, string message) => _logger.LogInformation($"[{response.CorrelationId()}] - {message}");
    public void LogInformation(Guid correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogInformation(string correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogInformation(string message) => _logger.LogInformation(message);

    public void LogWarning(BaseResponse response, string message) => _logger.LogInformation($"[{response.CorrelationId()}] - {message}");
    public void LogWarning(Guid correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogWarning(string correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogWarning(string message) => _logger.LogInformation(message);

    public void LogError(BaseResponse response, string message) => _logger.LogInformation($"[{response.CorrelationId()}] - {message}");
    public void LogError(Guid correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogError(string correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogError(string message) => _logger.LogInformation(message);

    public void LogDebug(BaseResponse response, string message) => _logger.LogInformation($"[{response.CorrelationId}] - {message}");
    public void LogDebug(Guid correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogDebug(string correlationId, string message) => _logger.LogInformation($"[{correlationId}] - {message}");
    public void LogDebug(string message) => _logger.LogInformation(message);

    public ILogger<T> FeaturesLogger()
    {
        return this._logger;
    }
}