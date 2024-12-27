namespace TodoApp.BuildingBlocks.Loggers;

public static class LoggersExtensions
{
    public static void AddServicesWritersLogger(this IHostApplicationBuilder builder)
    {
        builder.AddSeqEndpoint("seq");
        builder.Services.AddSerilog();
        builder.Services.AddLogging(options =>
        {
            options.AddSeq();
        });
    }
}
