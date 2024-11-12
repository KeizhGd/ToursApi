using slothlandapi.Dtos.Auth;
using slothlandapi.Request;
using slothlandapi.Response;

namespace slothlandapi.Services.AuthService
{
	public interface IAuthentication
	{
		Task<ResponseAPI<UserResponse>> Authenticate(AuthUserDto authUserDto);
		Task<ResponseAPI<UserResponse>> GetRefreshToken(RefreshTokenRequest refreshTokenRequest, string IdUsuario);
	}
}
