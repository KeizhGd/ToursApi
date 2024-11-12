using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
	public class ClientModel
	{
		[Key]
     
        [JsonPropertyName("identificacion")]
		public long identificacion { get; set; }

		[JsonPropertyName("nombre")]
		public string nombre { get; set; } = "";

		[JsonPropertyName("cedula")]
		public string cedula { get; set; } = "";

		[JsonPropertyName("TipoID")]
		public string TipoID { get; set; } = "";

		[JsonPropertyName("Telefono_01")]
		public string Telefono_01 { get; set; } = "";

		[JsonPropertyName("e_mail")]
		public string e_mail { get; set; } = "";

		[JsonPropertyName("direccion")]
		public string direccion { get; set; } = "";

		[JsonPropertyName("Contacto")]
		public string Contacto { get; set; } = "";

		[JsonPropertyName("TelefonoContacto")]
		public string TelefonoContacto { get; set; } = "";

		[JsonPropertyName("observaciones")]
		public string observaciones { get; set; } = "";



	}
}
