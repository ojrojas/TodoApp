namespace TodoApp.BuildingBlocks.CQRS;

public record BaseMessage
{
    protected Guid _correlation = Guid.NewGuid();    
    public Guid CorrelationId() => _correlation; 
}
