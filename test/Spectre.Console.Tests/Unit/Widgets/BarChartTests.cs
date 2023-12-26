namespace Spectre.Console.Tests.Unit;

[UsesVerify]
[ExpectationPath("Widgets/BarChart")]
public sealed class BarChartTests
{
    [Fact]
    [Expectation("Render")]
    public async Task Should_Render_Correctly()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Write(new BarChart()
            .Width(60)
            .Label("Number of fruits")
            .AddItem("Apple", 12)
            .AddItem("Orange", 54)
            .AddItem("Banana", 33));

        // Then
        await Verifier.Verify(console.Output);
    }

    [Fact]
    [Expectation("Zero_Value")]
    public async Task Should_Render_Correctly_2()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Write(new BarChart()
            .Width(60)
            .Label("Number of fruits")
            .AddItem("Apple", 0)
            .AddItem("Orange", 54)
            .AddItem("Banana", 33));

        // Then
        await Verifier.Verify(console.Output);
    }

    [Fact]
    [Expectation("Fixed_Max_Value")]
    public async Task Should_Render_Correctly_3()
    {
        // Given
        var console = new TestConsole();

        // When
        console.Write(new BarChart()
            .Width(60)
            .WithMaxValue(100)
            .Label("Number of fruits")
            .AddItem("Apple", 12)
            .AddItem("Orange", 54)
            .AddItem("Banana", 33));

        // Then
        await Verifier.Verify(console.Output);
    }

    [Fact]
    [Expectation("Style")]
    public async Task Should_Render_Correctly_WithStyle()
    {
        // Given
        var console = new TestConsole().EmitAnsiSequences();

        // When
        console.Write(new BarChart()
            .Width(60)
            .Label("Number of fruits")
            .AddItem("Apple", 12, Color.Red, Color.Red)
            .AddItem("Orange", 54, Color.Orange1, Color.Orange1)
            .AddItem("Banana", 33, Color.Yellow, Color.Yellow));

        // Then
        await Verifier.Verify(console.Output);
    }
}
