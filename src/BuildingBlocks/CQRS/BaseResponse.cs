namespace TodoApp.BuildingBlocks.CQRS;

public record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId)
    {
        _correlation = correlationId;
    }
}