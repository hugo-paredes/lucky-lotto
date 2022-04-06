using Core.Contracts;
using Core.Models;

namespace Core.Services;

public class BetService : IBetService
{
    ISequenceGenerator _sequenceGenerator;
    
    public BetService(ISequenceGenerator sequenceGenerator)
    {
        _sequenceGenerator = sequenceGenerator;
    }
    
    public IEnumerable<int> GenerateMainNumbers()
    {
        return _sequenceGenerator.GenerateUniqueSequence(numberOfItemsInSequence: 5, min: 1, max: 50).OrderBy(x=> x);
    }
    
    public IEnumerable<int> GenerateLuckNumbers()
    {
        return _sequenceGenerator.GenerateUniqueSequence(numberOfItemsInSequence: 2, min: 1, max: 12).OrderBy(x=> x);
    }

    public Bet GetBet()
    {
        return new Bet
        {
            MainNumbers = GenerateMainNumbers(),
            LuckyStars = GenerateLuckNumbers()
        };
    }
}
