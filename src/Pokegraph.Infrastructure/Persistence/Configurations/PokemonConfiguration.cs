namespace Pokegraph.Infrastructure.Persistence.Configurations;

internal sealed class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.ToTable("Pokemon");

        builder.HasKey(x => x.Number);
        builder.Property(x => x.Number)
            .HasColumnOrder(1)
            .HasConversion(
                v => v.Value,
                v => PokemonNumber.From(v))
            .HasColumnOrder(0);

        builder.Property(c => c.Name)            
            .HasColumnType("nvarchar(15)")
            .HasMaxLength(15)
            .HasColumnOrder(2)
            .IsRequired();

        builder.OwnsOne(p => p.PrimaryType, type =>
        {
            type.Property(p => p.Name)
                .HasColumnName("PrimaryType")
                .HasColumnType("nvarchar(15)")                
                .HasMaxLength(15)
                .HasColumnOrder(3)
                .IsRequired();
        });

        builder.OwnsOne(p => p.SecondaryType, type =>
        {
            type.Property(p => p.Name)
                .HasColumnName("SecondaryType")                
                .HasColumnType("nvarchar(15)")
                .HasMaxLength(15)
                .HasColumnOrder(4)
                .IsRequired(false);
        });        

        builder.Property(c => c.CatchRate)            
            .HasColumnName("CatchRate")
            .HasColumnType("decimal(5,2)")
            .HasColumnOrder(5)
            .IsRequired(false);

        builder.Property(c => c.IsLegendary)
            .HasColumnName("IsLegendary")
            .HasColumnType("bool")
            .HasDefaultValue(false)
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(c => c.Avatar)
            .HasColumnName("Avatar")
            .HasColumnType("nvarchar")
            .HasColumnOrder(7)
            .IsRequired(false);

        builder.OwnsOne(p => p.PhysicalAttributes, attr =>
        {
            attr.ToTable("PhysicalAttributes");

            attr.Property(c => c.Height)
               .HasColumnName("Height")
               .HasColumnType("decimal(5,2)");

            attr.Property(c => c.Weigth)
                .HasColumnName("Weigth")
                .HasColumnType("decimal(5,2)");
        });

        builder.OwnsOne(p => p.GenderRatio, ratio =>
        {
            ratio.ToTable("GenderRatios");

            ratio.Property(c => c.MaleRatio)
            .HasColumnName("MaleRatio")
            .HasColumnType("decimal(5,2)")
            .IsRequired(false);

            ratio.Property(c => c.FemaleRatio)
                .HasColumnName("FemaleRatio")
                .HasColumnType("decimal(5,2)")
                .IsRequired(false);
        });

        builder.OwnsOne(p => p.BaseStats, attr => 
        {
            attr.ToTable("BaseStats");

            attr.Property(c => c.HP)
              .HasColumnName("HP")
              .HasColumnType("integer")
              .IsRequired(false);

            attr.Property(c => c.Attack)
              .HasColumnName("Attack")
              .HasColumnType("integer")
              .IsRequired(false);

            attr.Property(c => c.Defense)
              .HasColumnName("Defense")
              .HasColumnType("integer")
              .IsRequired(false);

            attr.Property(c => c.SpecialAttack)
              .HasColumnName("SpecialAttack")
              .HasColumnType("integer")
              .IsRequired(false);

            attr.Property(c => c.SpecialDefense)
              .HasColumnName("SpecialDefense")
              .HasColumnType("integer")
              .IsRequired(false);

            attr.Property(c => c.Speed)
              .HasColumnName("Speed")
              .HasColumnType("integer")
              .IsRequired(false);
        });

        builder.HasOne(x => x.EvolvesTo)
            .WithMany(x => x.EvolvesFrom)
            .HasForeignKey(x => x.EvolvesToNumber)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}