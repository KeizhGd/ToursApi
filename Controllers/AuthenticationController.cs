using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using slothlandapi.Dtos.Auth;
using slothlandapi.Models;
using slothlandapi.Request;
using slothlandapi.Response;
using slothlandapi.Services.AuthService;
using System.IdentityModel.Tokens.Jwt;

namespace slothlandapi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController : Controller
	{
		private readonly IAuthentication authenticationService;

		public AuthenticationController(IAuthentication iauthenticationService)
		{
			this.authenticationService = iauthenticationService;
		}

		[HttpPost]
		[Route("Validate")]
		public async Task<IActionResult> Validate([FromBody] AuthUserDto userAuth)
		{
			try
			{
				var response  = await authenticationService.Authenticate(userAuth);
				if (response == null)
					return Unauthorized();

				return Ok(response);
			}
			catch (Exception ex)
			{

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

		}

		[HttpPost]
		[Route("GetRefreshToken")]
		public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenExpiredSupposed = tokenHandler.ReadJwtToken(refreshTokenRequest.TokenExpirado);

			if (tokenExpiredSupposed.ValidTo > DateTime.UtcNow)
				return BadRequest(new ResponseAPI<UserResponse> { Success = false, Message = "El token no ha expirado." });

			string idUsuario = tokenExpiredSupposed.Claims.First(x => x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

			var autorizationResponse = await authenticationService.GetRefreshToken(refreshTokenRequest, idUsuario);
		
			if (autorizationResponse.Success)
			{
				return Ok(autorizationResponse);
			}
			else
			{
				return BadRequest(autorizationResponse);
			}
		}
	}
}
