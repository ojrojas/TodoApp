namespace TodoApp.BuildingBlocks.ServiceDefaults.Extensions;

public static class GetDestination
{
    public static IEnumerable<string> GetDestinations(Claim claim)
    {
        return claim.Type switch
        {
            Claims.Name or
            Claims.Subject
                => new[] { Destinations.AccessToken, Destinations.IdentityToken },

            _ => [Destinations.AccessToken],
        };
    }
}