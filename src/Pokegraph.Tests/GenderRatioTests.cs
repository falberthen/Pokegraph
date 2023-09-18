namespace Pokegraph.Tests;

public class GenderRatioTests
{
    [Fact]
    public void CreatingGenderRatio_WithNegativeNumbers_ShouldThrownException()
    {
        // Given
        var maleRatio = -50;
        var femaleRatio = -50;

        // When
        var action = () => GenderRatio.From(maleRatio, femaleRatio);

        // Then
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void CreatingGenderRatio_WithSameNumbers_ShouldBeEqual()
    {
        // Given
        var genderRatio1 = GenderRatio.From(40, 60);
        var genderRatio2 = GenderRatio.From(40, 60);

        // When
        var areEqual = genderRatio1 == genderRatio2;

        // Then
        areEqual.Should().BeTrue();
        genderRatio1.Should().Be(genderRatio2);
    }

    [Fact]
    public void CreatingGenderRatio_WithOnlyOneRatio_ShouldBeAutomaticalyCalculated()
    {
        // Given
        var genderRatio1 = GenderRatio.From(0, 60);
        var genderRatio2 = GenderRatio.From(60, 0);

        // Then
        genderRatio1.MaleRatio.Should().Be(40);
        genderRatio2.FemaleRatio.Should().Be(40);
    }
}