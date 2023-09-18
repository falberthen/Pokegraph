namespace Pokegraph.Domain.SeedWork;

public interface IAggregateRoot<out TKey> where TKey : IntTypedId {}