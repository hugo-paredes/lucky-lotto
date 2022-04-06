using System.Linq;
using Core.Contracts;
using Core.Services;
using Xunit;

namespace Core.Tests;

public class BetServiceUT
{
    private readonly IBetService _betService;

    public BetServiceUT()
    {
        _betService = new BetService(new SequenceGenerator());
    }

    [Fact]
    public void GenerateMainNumbers_should_return_a_sequence_of_5_unique_numbers_ordered()
    {
        const int sequenceLength = 5;
        const int min = 1;
        const int max = 50;

        var mainNumbers = _betService.GenerateMainNumbers().ToList();

        Assert.NotEmpty(mainNumbers);
        Assert.Equal(sequenceLength, mainNumbers.Count);
        Assert.True(mainNumbers.Min() >= min);
        Assert.True(mainNumbers.Max() <= max);
        Assert.True(mainNumbers.Distinct().Count() == sequenceLength);
        Assert.True(mainNumbers.OrderBy(x => x).SequenceEqual(mainNumbers));
    }
    
    [Fact]
    public void GenerateMainNumbers_should_return_a_sequence_of_2_unique_numbers_ordered()
    {
        const int sequenceLength = 2;
        const int min = 1;
        const int max = 12;

        var mainNumbers = _betService.GenerateLuckNumbers().ToList();

        Assert.NotEmpty(mainNumbers);
        Assert.Equal(sequenceLength, mainNumbers.Count);
        Assert.True(mainNumbers.Min() >= min);
        Assert.True(mainNumbers.Max() <= max);
        Assert.True(mainNumbers.Distinct().Count() == sequenceLength);
        Assert.True(mainNumbers.OrderBy(x => x).SequenceEqual(mainNumbers));
    }
}
