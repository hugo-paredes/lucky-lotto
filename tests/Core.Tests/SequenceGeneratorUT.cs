using System.Linq;
using Core.Contracts;
using Core.Services;
using Xunit;

namespace Core.Tests;

public class SequenceGeneratorUT
{
    private readonly ISequenceGenerator _sequenceGenerator;

    public SequenceGeneratorUT()
    {
        _sequenceGenerator = new SequenceGenerator();
    }
    
    [Fact]
    public void GenerateUniqueSequence_should_generate_5_unique_sequence_of_numbers_between_1_and_10()
    {
        const int sequenceLength = 5;
        const int min = 1;
        const int max = 10;
        
        var sequence = _sequenceGenerator.GenerateUniqueSequence(sequenceLength, min, max).ToList();
        
        Assert.NotEmpty(sequence);
        Assert.Equal(sequenceLength, sequence.Count);
        Assert.True(sequence.Min() >= min);
        Assert.True(sequence.Max() <= max);
        Assert.True(sequence.Distinct().Count() == sequenceLength);
    }
}

