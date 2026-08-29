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
            Endpoint.GetCard => CardsEndpoints.GetCardById,
            Endpoint.GetCards => CardsEndpoints.GetCardsInList,
            Endpoint.CreateCard => CardsEndpoints.PostCards,
            Endpoint.UpdateCard => CardsEndpoints.PutCardById,
            Endpoint.DeleteCard => CardsEndpoints.DeleteCardById,
            _ => throw new ArgumentOutOfRangeException(nameof(endpoint), endpoint, null)
        };
    }
}
