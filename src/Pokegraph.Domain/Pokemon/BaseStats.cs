namespace Pokegraph.Domain.Pokemon;

public class BaseStats : ValueObject<BaseStats>
{
    public int? HP { get; private set; }
    public int? Attack { get; private set; }
    public int? Defense { get; private set; }
    public int? SpecialAttack { get; private set; }
    public int? SpecialDefense { get; private set; }
    public int? Speed { get; private set; }

    public static BaseStats From(PokemonData data)
    {
        EnsureValidState(data.HP);
        EnsureValidState(data.Attack);
        EnsureValidState(data.Defense);
        EnsureValidState(data.SpecialAttack);
        EnsureValidState(data.SpecialDefense);
        EnsureValidState(data.Speed);

        return new BaseStats(data);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        if (HP != null) yield return HP;
        if (Attack != null) yield return Attack;
        if (Defense != null) yield return Defense;
        if (SpecialAttack != null) yield return SpecialAttack;
        if (SpecialDefense != null) yield return SpecialDefense;
        if (Speed != null) yield return Speed;
    }

    protected BaseStats() { }

    private static void EnsureValidState(int? stat)
    {
        if(stat != null && stat < 0)
            throw new DomainException("Invalid stat value.");
    }

    private BaseStats(PokemonData data)
    {        
        HP = data.HP ??= 0;
        Attack = data.Attack ??= 0;
        Defense = data.Defense ??= 0;
        SpecialAttack = data.SpecialAttack ??= 0;
        SpecialDefense = data.SpecialDefense ??= 0;
        Speed = data.Speed ??= 0;
    }
}