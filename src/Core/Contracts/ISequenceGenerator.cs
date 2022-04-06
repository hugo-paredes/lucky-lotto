namespace Core.Contracts;

public interface ISequenceGenerator
{
    IEnumerable<int> GenerateUniqueSequence(int numberOfItemsInSequence, int min, int max);
}
