using System.Security.Cryptography;
using Core.Contracts;

namespace Core.Services;

public class SequenceGenerator : ISequenceGenerator
{
    public IEnumerable<int> GenerateUniqueSequence(int numberOfItemsInSequence, int min, int max)
    {
        var mainNumbers = new List<int>(numberOfItemsInSequence);
        do
        {
            var number = RandomNumberGenerator.GetInt32(min, max);
            if (!mainNumbers.Contains(number))
            {
                mainNumbers.Add(number);
            }
        } while (mainNumbers.Count < numberOfItemsInSequence);

        return mainNumbers;
    }

}