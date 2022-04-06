using Core.Contracts;
using Core.Models;

namespace Core.Services;

public class PlayLottoService : IPlayLottoService
{
    private readonly IBetService _betService;

    public PlayLottoService(IBetService betService)
    {
        _betService = betService;
    }
    
    public Game PlayGame(int howManyBets)
    {
        var bets = new List<Bet>();

        for (var i = 0; i < howManyBets; i++)
        {
            bets.Add(_betService.GetBet());
        }
        
        return new Game(howManyBets, bets);
    }
}
