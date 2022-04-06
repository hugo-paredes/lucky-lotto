namespace Core.Models;

public class Game
{
    public Game(int howManyBets, IEnumerable<Bet> bets)
    {
        NumberOfBets = howManyBets;
        Bets = bets;
    }

    int NumberOfBets { get; set; }
    public IEnumerable<Bet> Bets { get; set; }
}
