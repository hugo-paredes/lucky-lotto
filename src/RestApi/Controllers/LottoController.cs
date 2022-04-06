using System.Net.Mime;
using Core.Contracts;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LottoController : ControllerBase
{
    private readonly ILogger<LottoController> _logger;
    private readonly IPlayLottoService _playLottoService;

    public LottoController(ILogger<LottoController> logger, IPlayLottoService playLottoService)
    {
        _logger = logger;
        _playLottoService = (PlayLottoService)playLottoService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Game> Get([FromQuery] int numberOfBets = 1)
    {
        if (numberOfBets is < 1 or > 10)
        {
            return BadRequest("Number of bets must be between 1 and 10");
        }
        
        var game = _playLottoService.PlayGame(numberOfBets);
        return game;
    }
}
