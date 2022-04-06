using System.Linq;
using Core.Contracts;
using Core.Services;
using Xunit;

namespace Core.Tests;

public class PlayLottoUT
{
    private readonly IPlayLottoService _playLottoService;

    public PlayLottoUT()
    {
        _playLottoService = new PlayLottoService(new BetService(new SequenceGenerator()));
    }
    
    [Fact]
    public void PlayLotto_should_return_1_bet_when_we_play_1_bet()
    {
        const int numberOfBets = 1;
        
        var result = _playLottoService.PlayGame(numberOfBets);
        var bets = result.Bets.ToList();
        
        Assert.True(bets.Count == numberOfBets);
        Assert.True(bets[0].MainNumbers.Count() == 5);
        Assert.True(bets[0].LuckyStars.Count() == 2);
    }
}
