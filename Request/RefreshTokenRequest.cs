namespace slothlandapi.Request
{
	public class RefreshTokenRequest
	{
		public string TokenExpirado { get; set; }
		public string RefreshToken { get; set; }
	}
}
