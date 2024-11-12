using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class GuiaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("CedulaPasaporte")]
        public string CedulaPasaporte { get; set; }

        [JsonPropertyName("Edad")]
        public int Edad { get; set; }

        [JsonPropertyName("Licencia")]
        public string Licencia { get; set; }

        [JsonPropertyName("Celular")]
        public string Celular { get; set; }

        [JsonPropertyName("Correo")]
        public string Correo { get; set; }

        [JsonPropertyName("Certificado")]
        public string Certificado { get; set; } 
        
        [JsonPropertyName("NumeroCarnet")]
        public string NumeroCarnet { get; set; }


        [JsonPropertyName("Direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }

        [JsonPropertyName("Inhabilitado")]
        public bool? Inhabilitado { get; set; }
    }


}
