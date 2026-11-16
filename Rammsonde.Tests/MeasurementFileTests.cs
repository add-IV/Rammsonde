using Rammsonde;

namespace Rammsonde.Tests;

public class MeasurementFileTests
{
    [Fact]
    public void Parse_ValidLines_ReturnsSortedData()
    {
        var data = MeasurementFile.Parse(["20 5", "10 3", "30 12"]);

        Assert.Equal([10, 20, 30], data.Keys);
        Assert.Equal([3, 5, 12], data.Values);
    }

    [Fact]
    public void Parse_IgnoresBlankLinesAndExtraWhitespace()
    {
        var data = MeasurementFile.Parse(["  10   3 ", "", "\t20\t7", "   "]);

        Assert.Equal(2, data.Count);
        Assert.Equal(3, data[10]);
        Assert.Equal(7, data[20]);
    }

    [Fact]
    public void Parse_DuplicateDepth_LastValueWins()
    {
        var data = MeasurementFile.Parse(["10 3", "10 8"]);

        Assert.Single(data);
        Assert.Equal(8, data[10]);
    }

    [Fact]
    public void Parse_EmptyInput_ReturnsEmpty()
    {
        Assert.Empty(MeasurementFile.Parse([]));
    }

    [Theory]
    [InlineData("10")]
    [InlineData("10 3 5")]
    [InlineData("abc 3")]
    [InlineData("10 x")]
    [InlineData("10,5 3")]
    public void Parse_MalformedLine_ThrowsWithLineNumber(string badLine)
    {
        var ex = Assert.Throws<FormatException>(() => MeasurementFile.Parse(["10 3", badLine]));

        Assert.Contains("Zeile 2", ex.Message);
    }

    [Theory]
    [InlineData("0 3")]
    [InlineData("-10 3")]
    [InlineData("10 -1")]
    public void Parse_OutOfRangeValues_Throws(string badLine)
    {
        Assert.Throws<FormatException>(() => MeasurementFile.Parse([badLine]));
    }

    [Fact]
    public void Serialize_WritesSpaceSeparatedPairsOrderedByDepth()
    {
        var lines = MeasurementFile.Serialize(new Dictionary<int, int> { [20] = 5, [10] = 0 });

        Assert.Equal(["10 0", "20 5"], lines);
    }

    [Fact]
    public void SaveThenLoad_RoundTripsData()
    {
        var original = new SortedDictionary<int, int> { [10] = 2, [20] = 4, [30] = 15, [40] = 0 };
        string path = Path.GetTempFileName();
        try
        {
            MeasurementFile.Save(path, original);
            Assert.Equal(original, MeasurementFile.Load(path));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
