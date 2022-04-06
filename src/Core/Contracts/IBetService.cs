using Core.Models;

namespace Core.Contracts;

public interface IBetService
{
    IEnumerable<int> GenerateMainNumbers();
    IEnumerable<int> GenerateLuckNumbers();
    Bet GetBet();
}