namespace SpecFlow_Tests.Consts;

public enum Endpoint
{
    GetCard, 
    GetCards,
    CreateCard,
    UpdateCard,
    DeleteCard
}

public static class EndpointExtensions
{
    public static string GetEndpointUrl(this Endpoint endpoint)
    {
        return endpoint switch
        {
            Endpoint.GetCard => "/1/cards/{id}",
            Endpoint.GetCards => "/1/lists/{id}/cards",
            Endpoint.CreateCard => "/1/cards",
            Endpoint.UpdateCard => "/1/cards/{id}",
            Endpoint.DeleteCard => "/1/cards/{id}",
            _ => throw new ArgumentOutOfRangeException(nameof(endpoint), endpoint, null)
        };
    }
}
