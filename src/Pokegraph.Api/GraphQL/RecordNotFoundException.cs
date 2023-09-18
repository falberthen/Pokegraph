namespace Pokegraph.Api.GraphQL;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message) : base(message) { }
}