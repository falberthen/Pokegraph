namespace Pokegraph.Domain.SeedWork;

public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    where TKey : IntTypedId
{
    public TKey Number { get; set; } = default!;
    
}