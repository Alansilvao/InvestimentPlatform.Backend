using Application.Dtos.Requests.Assets;
using Application.Exceptions;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1/assets")]
[Authorize]
public class AssetsController : ControllerBase
{
    private readonly IGetAllAssetsUseCase _getAllAssetsUseCase;
    private readonly IGetAssetBySymbolUseCase _getAssetBySymbolUseCase;
    private readonly IPostAssetsUseCase _postAssetsUseCase;

    public AssetsController(
        IGetAllAssetsUseCase getAllAssetsUseCase, 
        IGetAssetBySymbolUseCase getAssetBySymbolUseCase, 
        IPostAssetsUseCase postAssetsUseCase)
    {
        _getAllAssetsUseCase = getAllAssetsUseCase;
        _getAssetBySymbolUseCase = getAssetBySymbolUseCase;
        _postAssetsUseCase = postAssetsUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssets()
    {
        try
        {
            var output = await _getAllAssetsUseCase.ExecuteAsync(new GetAllAssetsRequest());
            return Ok(output);
        }
        catch (Exception)
        {
            return StatusCode
            (
                StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" }
            );
        }
    }

    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetAssetBySymbol(string symbol)
    {
        try
        {
            var output = await _getAssetBySymbolUseCase.ExecuteAsync(symbol);
            return output is null ? BadRequest() : Ok(output);
        }
        catch (HttpStatusException ex)
        {
            return StatusCode(ex.StatusCode, new { ex.Message });
        }
        catch (Exception)
        {
            return StatusCode
            (
                StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" }
            );
        }
    }

    [HttpPost()]
    public async Task<IActionResult> PostAssets([FromBody] PostAssetsRequest request)
    {
        try
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            //var authorizationHeader = Request.Headers["Authorization"].ToString();
            //var token = authorizationHeader["Bearer ".Length..].Trim();

            //var output = await _postAssetsUseCase.ExecuteAsync(request, token);
            var output = await _postAssetsUseCase.ExecuteAsync(request, string.Empty);

            return Ok(output);
        }
        catch (HttpStatusException ex)
        {
            return StatusCode(ex.StatusCode, new { ex.Message });
        }
        catch (Exception)
        {
            return StatusCode
            (
                StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" }
            );
        }
    }
}