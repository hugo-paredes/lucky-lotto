using Core.Models;

namespace Core.Contracts;

public interface IPlayLottoService
{
    Game PlayGame(int howManyBets);
}