using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using slothlandapi.Contexts;
using slothlandapi.Dtos.Auth;
using slothlandapi.Models;
using slothlandapi.Request;
using slothlandapi.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace slothlandapi.Services.AuthService
{
	public class AuthenticationService : IAuthentication
	{
		private readonly string secretKey;

		private readonly ConnectionSQLServer _context;

		public AuthenticationService(ConnectionSQLServer context, IConfiguration configuration)
		{
			_context = context;
			secretKey = configuration.GetSection("settings").GetSection("secretkey").ToString()!;
		}

		public async Task<ResponseAPI<UserResponse>> Authenticate(AuthUserDto authUserDto)
		{
			ResponseAPI<UserResponse> responseAPI = new ResponseAPI<UserResponse>();
			string password = authUserDto.Password;

			try
			{
				UserModel? userModel = await _context.Usuarios.Where(u => u.Nombre == authUserDto.UserName 
				&& u.Clave_Interna == password).FirstOrDefaultAsync();

				if (userModel == null)
				{
					responseAPI.Success = false;
					responseAPI.Message = "Usuario o contraseña o incorrecta!";

				}
				else
				{
					
					string tokenCreated = GenerateToken(userModel);
					string refreshTokenCreated = GenerateRefreshToken();

					return await SaveHistoryRefreshToken(userModel.Id_Usuario, userModel.Nombre, tokenCreated, refreshTokenCreated);
					//responseAPI.DataResponse = new UserResponse
					//{
					//	Id = userModel.Id_Usuario,
					//	UserName = userModel.Nombre,
					//	Token = GenerateToken(userModel),
					//	RefreshToken = refreshTokenCreated
					//};
					//responseAPI.Message = "Autenticado";
				}

				return responseAPI;
			}
			catch (Exception ex)
			{
				responseAPI.Success = false;
				responseAPI.Message = "Ha ocurrido un error inesperado.";
				responseAPI.DataError = ex.Message;
				return responseAPI;
			}


		}

		public async Task<ResponseAPI<UserResponse>> GetRefreshToken(RefreshTokenRequest refreshTokenRequest, string IdUsuario)
		{
			ResponseAPI<UserResponse> responseAPI = new ResponseAPI<UserResponse>();

			UserModel? userModel = await _context.Usuarios.Where(u => u.Id_Usuario == IdUsuario).FirstOrDefaultAsync();

			var refreshTokenFound = _context.HistorialRefreshToken.FirstOrDefault(h => 
			h.Token == refreshTokenRequest.TokenExpirado && 
			h.RefreshToken == refreshTokenRequest.RefreshToken &&
			h.IdUsuario == IdUsuario);



			if (refreshTokenFound == null)
			{
				responseAPI.Success = false;
				responseAPI.Message = "No se encontro el token.";
				return responseAPI;
			}

			var refreshTokenCreated = GenerateRefreshToken();
			var tokenCreated = GenerateToken(userModel!);

			return await SaveHistoryRefreshToken(userModel.Id_Usuario, userModel.Nombre, tokenCreated, refreshTokenCreated);
				

		}

		private string GenerateToken(UserModel userModel)
		{
			try
			{
				var keyBytes = Encoding.ASCII.GetBytes(secretKey);
				var claims = new ClaimsIdentity();

				claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userModel.Id_Usuario));
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = claims,
					Expires = DateTime.UtcNow.AddMinutes(400),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

				string tokenCreated = tokenHandler.WriteToken(tokenConfig);

				return tokenCreated;
			}
			catch (Exception)
			{

				throw;
			}
		}
	
		private string GenerateRefreshToken()
		{
			var byteArray = new byte[64];
			var refreshToken = "";

			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(byteArray);
				refreshToken = Convert.ToBase64String(byteArray);
			}
			return refreshToken;
		}

		private async Task<ResponseAPI<UserResponse>> SaveHistoryRefreshToken(string IdUsuario, string userName, string token, string refreshToken)
		{
			ResponseAPI<UserResponse> responseAPI = new ResponseAPI<UserResponse>();
			try
			{

                
				var historyRefreshToken = new HistoryRefreshTokenModel
				{
					IdUsuario = IdUsuario,
					Token = token,
					RefreshToken = refreshToken,
					FechaCreacion = DateTime.UtcNow,
					FechaExpiracion = DateTime.UtcNow.AddMinutes(800)
					
				};
			

               

                await _context.HistorialRefreshToken.AddAsync(historyRefreshToken);
				await _context.SaveChangesAsync();

				responseAPI.DataResponse = new UserResponse
				{
					Id = IdUsuario,
					UserName = userName,
					Token = token,
					RefreshToken = refreshToken
				};
				responseAPI.Message = "Autenticado";

				return responseAPI;
			}
			catch (Exception)
			{

				throw;
			}
		}
	
	}
}
