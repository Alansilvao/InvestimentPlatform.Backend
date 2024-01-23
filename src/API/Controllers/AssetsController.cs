using Application.Dtos.Requests.Assets;
using Application.Exceptions;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace API.Controllers;

[ExcludeFromCodeCoverage]
[Route("api/v1/assets")]
[Authorize]
public class AssetsController : ControllerBase
{
    private readonly IGetAllAssetsUseCase _getAllAssetsUseCase;
    private readonly IGetAssetBySymbolUseCase _getAssetBySymbolUseCase;
    private readonly IPostAssetsUseCase _postAssetsUseCase;
    private readonly IPutAssetsUseCase _putAssetsUseCase;
    private readonly IDeleteAssetsUseCase _deleteAssetsUseCase;

    public AssetsController(
        IGetAllAssetsUseCase getAllAssetsUseCase, 
        IGetAssetBySymbolUseCase getAssetBySymbolUseCase, 
        IPostAssetsUseCase postAssetsUseCase,
        IPutAssetsUseCase putAssetsRequest,
        IDeleteAssetsUseCase deleteAssetsRequest)
    {
        _getAllAssetsUseCase = getAllAssetsUseCase;
        _getAssetBySymbolUseCase = getAssetBySymbolUseCase;
        _postAssetsUseCase = postAssetsUseCase;
        _putAssetsUseCase = putAssetsRequest;
        _deleteAssetsUseCase = deleteAssetsRequest;
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

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var token = authorizationHeader["Bearer ".Length..].Trim();

            var output = await _postAssetsUseCase.ExecuteAsync(request, token);

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

    [HttpPut("Change/")]
    [AllowAnonymous]
    public async Task<IActionResult> PutAssets([FromBody] PutAssetsRequest request)
    {
        try
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            var output = await _putAssetsUseCase.ExecuteAsync(request, string.Empty);

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

    [HttpDelete("Remove/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteAssets([FromBody] DeleteAssetsRequest request)
    {
        try
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            //var authorizationHeader = Request.Headers["Authorization"].ToString();
            //var token = authorizationHeader["Bearer ".Length..].Trim();

            //var output = await _putAssetsUseCase.ExecuteAsync(request, token);
            var output = await _deleteAssetsUseCase.ExecuteAsync(request, string.Empty);

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