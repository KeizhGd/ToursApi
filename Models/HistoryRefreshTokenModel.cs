using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
	public class HistoryRefreshTokenModel
	{
		[Key]
		[JsonPropertyName("IdHistorialToken")]
		public int IdHistorialToken { get; set; }

		[JsonPropertyName("IdUsuario")]
		public string IdUsuario { get; set; }

		[JsonPropertyName("Token")]
		public string Token { get; set; }

		[JsonPropertyName("RefreshToken")]
		public string RefreshToken { get; set; }

		[JsonPropertyName("FechaCreacion")]
		public DateTime FechaCreacion { get; set; }

		[JsonPropertyName("FechaExpiracion")]
		public DateTime FechaExpiracion { get; set; }

		[JsonPropertyName("EsActivo")]
		public bool EsActivo { get; set; }
	}
}
