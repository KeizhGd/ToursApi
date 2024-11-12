using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
	public class UserModel
	{
		[Key]
		[JsonPropertyName("Id")]
		public long Id { get; set; }

		[JsonPropertyName("Id_Usuario")]
		public string Id_Usuario { get; set; }

		[JsonPropertyName("Nombre")]
		public string Nombre { get; set; }

		[JsonPropertyName("Clave_Entrada")]
		public string Clave_Entrada { get; set; }

		[JsonPropertyName("Clave_Interna")]
		public string Clave_Interna { get; set; }

		[JsonPropertyName("CambiarPrecio")]
		public bool CambiarPrecio { get; set; }

		[JsonPropertyName("Porc_Precio")]
		public double Porc_Precio { get; set; }

		[JsonPropertyName("Aplicar_Desc")]
		public bool Aplicar_Desc { get; set; }

		[JsonPropertyName("Porc_Desc")]
		public double Porc_Desc { get; set; }

		[JsonPropertyName("Exist_Negativa")]
		public bool Exist_Negativa { get; set; }

		[JsonPropertyName("PermiteVenderPerdiendo")]
		public bool PermiteVenderPerdiendo { get; set; }

		[JsonPropertyName("Cedula")]
		public string Cedula { get; set; }















	}
}
