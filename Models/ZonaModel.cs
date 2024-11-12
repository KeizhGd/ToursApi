using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace slothlandapi.Models
{
    public class ZonaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public long? Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("Direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("CodigoPostal")]
        public long? CodigoPostal { get; set; }

        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }

        [JsonPropertyName("Inhabilitado")]
        public bool? Inhabilitado { get; set; }
    }
}
